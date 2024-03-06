using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Szpital.Exceptions;
using Szpital.Models;
using Szpital.ViewModels;
using Szpital.ViewModels.GeneralManager;
using Szpital.ViewModels.Manager;
using static Szpital.ViewModels.VisitViewModel;

namespace Szpital.DbContexts
{
    public static class DbContext
    {
        private const string connectionStr = "Data source=DESKTOP-HJ1SM1F\\SQLEXPRESS;Initial catalog=Szpital;Integrated Security=True";


        private static void HashAllPasswords()
        {
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                List<string> passwords = GetAllPasswords();

                for (int i = 0; i < passwords.Count; i++)
                {
                    string passwordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(passwords[i], 13);

                    int j = i;
                    string updatePasswordsQuery = $@"update Accounts set Password_ = '{passwordHash}' where Employee_id = {++j}";

                    using (SqlCommand updatePasswordsCommand = new SqlCommand(updatePasswordsQuery, connection))
                    {
                        updatePasswordsCommand.ExecuteNonQuery();
                    }
                }
            }
        }

        private static List<string> GetAllPasswords()
        {
            List<string> passwords = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                string selectPasswordsQuery = $@"select Password_ from Accounts";

                using (SqlCommand selectPasswordCommand  = new SqlCommand(selectPasswordsQuery, connection))
                using (SqlDataReader reader = selectPasswordCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        passwords.Add(reader["Password_"].ToString());
                    }
                }
            }

            return passwords;
        }

        public static Account IdentifyUser(string username, string password)
        {
            Account? result = null;
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                
                string selectAccountQuery = $@"select * from Accounts where Username = '{username}'";

                using (SqlCommand selectLoginCommand = new SqlCommand(selectAccountQuery, connection))
                using (SqlDataReader reader = selectLoginCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result = MapDataToAccount(reader);
                    }
                }
            }
            if (result is null)
            {
                throw new UserIdentifyException("Niepoprawne hasło lub użytkownik.");
            }
            else if (!BCrypt.Net.BCrypt.EnhancedVerify(password, result.Password))
            {
                throw new UserIdentifyException("Niepoprawne hasło lub użytkownik.");
            }

            return result;
        }

        public static Employee? GetUserEmployee(Account account)
        {
            Employee? result = null;
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                string selectEmployeeQuery = $@"select * from Employees where Employee_id = {account.EmployeeId}";

                using (SqlCommand selectAccountCommand = new SqlCommand(selectEmployeeQuery, connection))
                using (SqlDataReader reader = selectAccountCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result = MapDataToEmployee(reader);
                    }
                }
            }

            return result;
        }

        public static string GetHospitalDepartment(Employee employee)
        {
            string? result = null;
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                string selectHospitalDepartment = $@"select Department_name from Hospital_departments where Department_id = (select Department_id from Employees where Employee_id = {employee.EmployeeId})";

                using (SqlCommand selectHospitalDepartmentCommand = new SqlCommand(selectHospitalDepartment, connection))
                using (SqlDataReader reader = selectHospitalDepartmentCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result = reader["Department_name"].ToString();
                    }
                }
            }

            return result;
        }

        public static string GetCurrentPassword(Account account)
        {
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                string selectCurrentPassword = $@"select Password_ from Accounts where Employee_id = {account.EmployeeId}";
                string? currentPassword = null;

                using (SqlCommand selectCurrentPasswordCommand = new SqlCommand(selectCurrentPassword, connection))
                using (SqlDataReader reader = selectCurrentPasswordCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        currentPassword = reader["Password_"].ToString();
                    }
                }

                return currentPassword;
            }
        }

        private static Employee MapDataToEmployee(SqlDataReader reader)
        {
            Employee employee = new Employee(
                                (int)reader["Employee_id"],
                                (int)reader["Department_id"],
                                reader["Position"].ToString(),
                                reader["Specialty"].ToString(),
                                reader["First_name"].ToString(),
                                reader["Last_name"].ToString(),
                                reader["Pesel"].ToString(),
                                reader["Phone_number"].ToString(),
                                reader["Email"].ToString(),
                                (DateTime)reader["Birth_date"],
                                reader["Address_"].ToString(),
                                reader["City"].ToString(),
                                (DateTime)reader["Employment_date"],
                                (decimal)reader["Salary"],
                                (bool)reader["Is_deleted"]
                                );
            return employee;
        }

        private static Account MapDataToAccount(SqlDataReader reader)
        {
            Account account = new Account(
                            (int)reader["Employee_id"],
                            reader["Password_"].ToString(),
                            reader["Username"].ToString());
            return account;
        }

        public static void ChangePassword(Account account, string newPassword)
        {
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();

                string passwordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(newPassword, 13);

                string updatePasswordQuery = $@"update Accounts set Password_ = '{passwordHash}' where Employee_id = {account.EmployeeId}";

                using (SqlCommand updatePasswordCommand = new SqlCommand(updatePasswordQuery, connection))
                {
                    updatePasswordCommand.ExecuteNonQuery();
                }
            }
        }

        public static ObservableCollection<MDListItemViewModel>? GetManagerDoctors(Employee employee)
        {
            ObservableCollection<MDListItemViewModel> result = new ObservableCollection<MDListItemViewModel>();
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                string selectDoctorsQuery = $@"select Employee_id, First_name, Last_name from Employees where Department_id = (select Department_id from Employees where Employee_id = {employee.EmployeeId}) and Position != 'Kierownik'";

                using (SqlCommand selectDoctorsCommand = new SqlCommand(selectDoctorsQuery, connection))
                using (SqlDataReader reader = selectDoctorsCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(MapDataToManagerDoctorListItemViewModel(reader));
                    }
                }
            }

            return result;
        }

        private static MDListItemViewModel MapDataToManagerDoctorListItemViewModel(SqlDataReader reader)
        {
            MDListItemViewModel managerDoctorListItemViewModel = new MDListItemViewModel(
                (int)reader["Employee_id"],
                reader["First_name"].ToString(),
                reader["Last_name"].ToString()
                );

            return managerDoctorListItemViewModel;
        }

        public static ObservableCollection<GMDListItemViewModel>? GetAllGMEmployees()
        {
            ObservableCollection<GMDListItemViewModel> result = new ObservableCollection<GMDListItemViewModel>();
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                string selectEmployeesQuery = $@"select Employee_id, First_name, Last_name from Employees where Position != 'Główny kierownik'";

                using (SqlCommand selectEmployeesCommand = new SqlCommand(selectEmployeesQuery, connection))
                using (SqlDataReader reader = selectEmployeesCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(MapDataToGeneralManagerDoctorListItemViewModel(reader));
                    }
                }
            }

            return result;
        }

        private static GMDListItemViewModel MapDataToGeneralManagerDoctorListItemViewModel(SqlDataReader reader)
        {
            GMDListItemViewModel generalManagerDoctorListItemViewModel = new GMDListItemViewModel(
                (int)reader["Employee_id"],
                reader["First_name"].ToString(),
                reader["Last_name"].ToString()
                );

            return generalManagerDoctorListItemViewModel;
        }

        public static ObservableCollection<MDListItemViewModel>? GetAllDoctors()
        {
            ObservableCollection<MDListItemViewModel> result = new ObservableCollection<MDListItemViewModel>();
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                string selectDoctorsQuery = $@"select Employee_id, First_name, Last_name from Employees where Position = 'Doktor'";

                using (SqlCommand selectDoctorsCommand = new SqlCommand(selectDoctorsQuery, connection))
                using (SqlDataReader reader = selectDoctorsCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(MapDataToManagerDoctorListItemViewModel(reader));
                    }
                }
            }

            return result;
        }

        public static void AddPatient(string firstName, string lastName, string pesel, DateTime birthDate, string city, string address, string phoneNumber)
        {
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                string insertPatientQuery = $@"insert into Patients values('{firstName}', '{lastName}', '{pesel}', '{birthDate.Year}-{birthDate.Month}-{birthDate.Day}', '{city}', '{address}', '{phoneNumber}')";

                using (SqlCommand insertPatientCommand = new SqlCommand(insertPatientQuery, connection))
                {
                    insertPatientCommand.ExecuteNonQuery();
                }
            }
        }
        
        public static List<string> GetAllPesels()
        {
            List<string> pesels = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                string selectAllPeselsQuery = $@"select Pesel from Patients union all select Pesel from Employees";

                using (SqlCommand selectAllPeselsCommand = new SqlCommand(selectAllPeselsQuery, connection))
                using (SqlDataReader reader = selectAllPeselsCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        pesels.Add(reader["Pesel"].ToString());
                    }
                }
            }

            return pesels;
        }

        public static Employee GetEmployeeInfo(int employeeId)
        {
            Employee employee = null;
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                string selectEmployeeQuery = $@"select * from Employees where Employee_id = {employeeId}";

                using (SqlCommand selectEmployeeCommand = new SqlCommand(selectEmployeeQuery, connection))
                using (SqlDataReader reader = selectEmployeeCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        employee = MapDataToEmployee(reader);
                    }
                }
            }

            return employee;
        }

        public static Patient GetPatient(int patientId)
        {
            Patient patient = null;
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                string selectPatientQuery = $@"select * from Patients where Patient_id = {patientId}";

                using (SqlCommand selectPatientCommand = new SqlCommand(selectPatientQuery, connection))
                using (SqlDataReader reader = selectPatientCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        patient = MapDataToPatient(reader);
                    }
                }
            }

            return patient;
        }

        private static Patient MapDataToPatient(SqlDataReader reader)
        {
            Patient patient = new Patient(
                (int)reader["Patient_id"],
                reader["First_name"].ToString(),
                reader["Last_name"].ToString(),
                reader["Pesel"].ToString(),
                (DateTime)reader["Birth_date"],
                reader["City"].ToString(),
                reader["Address_"].ToString(),
                reader["Phone_number"].ToString()
                );
            
            return patient;
        }


        public static ObservableCollection<VisitViewModel> GetVisits(int doctorId)
        {
            ObservableCollection<VisitViewModel> visits = new ObservableCollection<VisitViewModel>();
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                string selectDoctorVisitDatesQuery = $@"select distinct Year(Visit_date) Year, Month(Visit_date) Month, Day(Visit_date) Day from Visits where Doctor_id = {doctorId}";

                using (SqlCommand selectDoctorVisitDatesCommand = new SqlCommand(selectDoctorVisitDatesQuery, connection))
                using (SqlDataReader reader = selectDoctorVisitDatesCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        VisitViewModel visit = new VisitViewModel(new VisitDate(
                            (int)reader["Day"],
                            (int)reader["Month"],
                            (int)reader["Year"]
                            ));
                        visit.Items = DbContext.GetVisit(visit, doctorId);

                        visits.Add(visit);
                    }
                }
            }

            return visits;
        }

        private static ObservableCollection<VisitItem> GetVisit(VisitViewModel visitDate, int doctorId)
        {
            ObservableCollection<VisitItem> visits = new ObservableCollection<VisitItem>();
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                string selectDoctorDateVisitsQuery = $@"select * from Visits where Year(Visit_date) = {visitDate.Year} and Month(Visit_date) = {visitDate.Month} and Day(Visit_date) = {visitDate.Day} and Doctor_id = {doctorId}";

                using (SqlCommand selectDoctorDateVisitsCommand = new SqlCommand(selectDoctorDateVisitsQuery, connection))
                using (SqlDataReader reader = selectDoctorDateVisitsCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        VisitItem visit = MapDataToVisit(reader);
                        visits.Add(visit);
                    }
                }
            }

            return visits;
        }

        private static VisitItem MapDataToVisit(SqlDataReader reader)
        {
            VisitItem visitItem = new VisitItem(new Visit(
                            (int)reader["Visit_id"],
                            (int)reader["Patient_id"],
                            (int)reader["Doctor_id"],
                            (DateTime)reader["Visit_date"],
                            (int)reader["Office_no"],
                            reader["Comments"].ToString()
                            ));

            return visitItem;
        }
    }
}
