using System;
using System.Data.SqlClient;
namespace DZ22
{
    internal class Program
    {
        private static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ModCountry;Integrated Security=True;Connect Timeout=30;";

        static void Main(string[] args)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                Console.WriteLine("<---All Country--->\n");
                AllCountryInfo(connection);

                Console.WriteLine("\n<----------------->\n");
                AllNameCountry(connection);

                Console.WriteLine("\n<----------------->\n");
                AllCapital(connection);

                Console.WriteLine("\n<----------------->\n");
                BigCities(connection, 1);

                Console.WriteLine("\n<----------------->\n");
                CapitalsWithPopulationMoreThanFiveMillion(connection);

                Console.WriteLine("\n<----------------->\n");
                EuropCountries(connection);

                Console.WriteLine("\n<----------------->\n");
                CapitalsWithAP(connection);

                Console.WriteLine("\n<----------------->\n");
                CapitalsStartingWithK(connection);

                Console.WriteLine("\n<----------------->\n");
                CountriesByArea(connection, 100000, 1000000);

                Console.WriteLine("\n<----------------->\n");
                CountriesByPopulation(connection, 50000000);

                Console.WriteLine("\n<----------------->\n");
                Top5LargestCountry(connection);

                Console.WriteLine("\n<----------------->\n");
                Top5LargestCapital(connection);

                Console.WriteLine("\n<----------------->\n");
                CountryLargestArea(connection);

                Console.WriteLine("\n<----------------->\n");
                CapitalLargestPopulation(connection);

                Console.WriteLine("\n<----------------->\n");
                SmallestEuropCountry(connection);

                Console.WriteLine("\n<----------------->\n");
                AverageAreaInEurop(connection);

                Console.WriteLine("\n<----------------->\n");
                Top3CitiesByPopulationInCountry(connection, 1);

                Console.WriteLine("\n<----------------->\n");
                TotalCountries(connection);

                Console.WriteLine("\n<----------------->\n");
                ContinentMaxCountries(connection);

                Console.WriteLine("\n<----------------->\n");
                CountryCountByContinent(connection);
            }
        }
        private static void AllCountryInfo(SqlConnection connection)
        {
            string query = @"SELECT c.Name AS CountryName, c.Area, c.Continent, 
                            cap.Name AS CapitalName, cap.Population AS CapitalPopulation,
                            bc.Name AS CityName, bc.Population AS CityPopulation
                            FROM Country c
                            JOIN Capitalss cap ON c.ID = cap.CountryID
                            JOIN BigCitiess bc ON c.ID = bc.CountryID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Country: {reader["CountryName"]},\nArea: {reader["Area"]},\nContinent: {reader["Continent"]}, " +
                                          $"\nCapital: {reader["CapitalName"]}, \nCapital Population: {reader["CapitalPopulation"]}, " +
                                          $"\nCity: {reader["CityName"]}, \nCity Population: {reader["CityPopulation"]}\n");
                    }
                }
            }
        }

        private static void AllNameCountry(SqlConnection connection)
        {
            string query = "SELECT Name FROM Country";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Country Name: {reader["Name"]}");
                    }
                }
            }
        }

        private static void AllCapital(SqlConnection connection)
        {
            string query = "SELECT Name FROM Capitalss";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Capital Name: {reader["Name"]}");
                    }
                }
            }
        }

        private static void BigCities(SqlConnection connection, int countryID)
        {
            string query = "SELECT Name FROM BigCitiess WHERE CountryID = @CountryID";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@CountryID", countryID);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Big City: {reader["Name"]}");
                    }
                }
            }
        }

        private static void CapitalsWithPopulationMoreThanFiveMillion(SqlConnection connection)
        {
            string query = "SELECT Name FROM Capitalss WHERE Population > 5000000";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Capital Name: {reader["Name"]}");
                    }
                }
            }
        }

        private static void EuropCountries(SqlConnection connection)
        {
            string query = "SELECT Name FROM Country WHERE Continent = 'Europe'";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"European Country: {reader["Name"]}");
                    }
                }
            }
        }
        private static void CapitalsWithAP(SqlConnection connection)
        {
            string query = "SELECT Name FROM Capitalss WHERE Name LIKE '%a%' AND Name LIKE '%p%'";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Capital Name: {reader["Name"]}");
                    }
                }
            }
        }

        private static void CapitalsStartingWithK(SqlConnection connection)
        {
            string query = "SELECT Name FROM Capitalss WHERE Name LIKE 'k%'";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Capital Name: {reader["Name"]}");
                    }
                }
            }
        }

        private static void CountriesByArea(SqlConnection connection, float minArea, float maxArea)
        {
            string query = "SELECT Name FROM Country WHERE Area > @MinArea AND Area < @MaxArea";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@MinArea", minArea);
                command.Parameters.AddWithValue("@MaxArea", maxArea);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Country Name: {reader["Name"]}");
                    }
                }
            }
        }

        private static void CountriesByPopulation(SqlConnection connection, int population)
        {
            string query = "SELECT Name FROM Country WHERE Population > @Population";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Population", population);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Country Name: {reader["Name"]}");
                    }
                }
            }
        }
        private static void Top5LargestCountry(SqlConnection connection)
        {
            string query = "SELECT TOP 5 * FROM Country ORDER BY Area DESC";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Country Name: {reader["Name"]}, Area: {reader["Area"]}");
                    }
                }
            }
        }

        private static void Top5LargestCapital(SqlConnection connection)
        {
            string query = "SELECT TOP 5 * FROM Capitalss ORDER BY Population DESC";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Capital Name: {reader["Name"]}, Population: {reader["Population"]}");
                    }
                }
            }
        }

        private static void CountryLargestArea(SqlConnection connection)
        {
            string query = "SELECT * FROM Country ORDER BY Area DESC OFFSET 0 ROWS FETCH NEXT 1 ROW ONLY";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Console.WriteLine($"Country with Largest Area: {reader["Name"]}, Area: {reader["Area"]}");
                    }
                }
            }
        }

        private static void CapitalLargestPopulation(SqlConnection connection)
        {
            string query = "SELECT * FROM Capitalss ORDER BY Population DESC OFFSET 0 ROWS FETCH NEXT 1 ROW ONLY";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Console.WriteLine($"Capital with Largest Population: {reader["Name"]}, Population: {reader["Population"]}");
                    }
                }
            }
        }

        private static void SmallestEuropCountry(SqlConnection connection)
        {
            string query = "SELECT * FROM Country WHERE Continent = 'Europe' ORDER BY Area ASC OFFSET 0 ROWS FETCH NEXT 1 ROW ONLY";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Console.WriteLine($"Smallest European Country: {reader["Name"]}, Area: {reader["Area"]}");
                    }
                }
            }
        }

        private static void AverageAreaInEurop(SqlConnection connection)
        {
            string query = "SELECT AVG(Area) AS AverageArea FROM Country WHERE Continent = 'Europe'";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Console.WriteLine($"Average Area in Europe: {reader["AverageArea"]}");
                    }
                }
            }
        }

        private static void Top3CitiesByPopulationInCountry(SqlConnection connection, int countryID)
        {
            string query = "SELECT TOP 3 * FROM BigCitiess WHERE CountryID = @CountryID ORDER BY Population DESC";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@CountryID", countryID);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"City: {reader["Name"]}, Population: {reader["Population"]}");
                    }
                }
            }
        }

        private static void TotalCountries(SqlConnection connection)
        {
            string query = "SELECT COUNT(*) FROM Country";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                object result = command.ExecuteScalar();
                Console.WriteLine($"Total number of countries: {result}");
            }
        }

        private static void ContinentMaxCountries(SqlConnection connection)
        {
            string query = "SELECT Continent, COUNT(*) AS Count FROM Country GROUP BY Continent ORDER BY Count DESC OFFSET 0 ROWS FETCH NEXT 1 ROW ONLY";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Console.WriteLine($"Continent with most countries: {reader["Continent"]}, Count: {reader["Count"]}");
                    }
                }
            }
        }

        private static void CountryCountByContinent(SqlConnection connection)
        {
            string query = "SELECT Continent, COUNT(*) AS CountryCount FROM Country GROUP BY Continent";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Continent: {reader["Continent"]}, Country Count: {reader["CountryCount"]}");
                    }
                }
            }
        }
    }
}