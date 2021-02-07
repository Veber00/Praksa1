using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarOwners.Repository.Common;
using System.Data.SqlClient;
using CarOwners.Model;

namespace CarOwners.Repository
{
    public class CarOwnersRepository : ICarOwnersRepository
    {
        SqlConnection con = new SqlConnection("data source=.; database=master; integrated security=SSPI");

        public async Task<List<string>> GetAllAsync()
        {
            List<string> ret = new List<string>();

            using (con)
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM person", con);

                con.Open();
                SqlDataReader rdr = await Task.Run(() => cmd.ExecuteReader());


                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        ret.Add(rdr.GetInt32(0) + " " + rdr.GetString(1) + " " + rdr.GetInt32(2));
                    }

                }

                con.Close();

            }

            return ret;
        }

        public async Task<List<string>> GetPersonCarAsync(int person_id)
        {
            List<string> ret = new List<string>();

            using (con)
            {

                SqlCommand cmd = new SqlCommand(String.Format("SELECT car_model, car_year FROM cars_owned " + "where person_id={0}", person_id), con);

                con.Open();
                SqlDataReader rdr = await Task.Run(() => cmd.ExecuteReader());


                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        ret.Add(rdr.GetString(0) + " " + rdr.GetInt32(1));
                    }
                }
                con.Close();
                return ret;

            }

            
        }


        public async Task<string> NewPersonAsync(Person person)
        {
            using (con)
            {
                SqlCommand cmd = new SqlCommand(String.Format("INSERT INTO person (person_id, full_name, age) VALUES ({0}, '{1}', {2})", person.PersonId, person.FullName, person.Age), con);

                con.Open();

                try
                {
                    await Task.Run(() => cmd.ExecuteNonQuery());
                    con.Close();
                    return ("OK");
                }
                catch (Exception e)
                {
                    con.Close();
                    return e.ToString();
                }
            }

        }


        public async Task<string> UpdateCarAsync(int person_id, Car car)
        {
            using (con)
            {

                SqlCommand help = new SqlCommand(String.Format("SELECT person_id FROM cars_owned WHERE person_id={0} and car_model='{1}' and cars_owned_id={2}", person_id, car.CarModel, car.CarsOwnedId), con);

                
                con.Open();


                try
                {
                    SqlDataReader rdr = await Task.Run(() => help.ExecuteReader());
                    if(!rdr.HasRows)
                    {
                        con.Close();
                        return ("The car you are trying to update is not in the database!");
                    } else
                    {
                        rdr.Close();
                        SqlCommand cmd = new SqlCommand(String.Format("UPDATE cars_owned SET car_millage = {0} WHERE person_id={1} and car_model='{2}' and cars_owned_id='{3}'", car.CarMillage, person_id, car.CarModel, car.CarsOwnedId), con);
                        await Task.Run(() => cmd.ExecuteNonQuery());
                        con.Close();
                        return ("OK");
                    }
                }
                catch (Exception e)
                {
                    con.Close();
                    return e.ToString();
                }
            }

        }


        public async Task<string> DeleteCarAsync(int person_id, Car car)
        {
            using (con)
            {

                SqlCommand help = new SqlCommand(String.Format("SELECT person_id FROM cars_owned WHERE person_id = {0} AND car_model = '{1}' and cars_owned_id={2};", person_id, car.CarModel, car.CarsOwnedId), con);
                
                con.Open();

                try
                {
                    SqlDataReader rdr = await Task.Run(() => help.ExecuteReader());

                    if (!rdr.HasRows)
                    {
                        con.Close();
                        return ("The car you are trying to delete is not in the database!");
                    }
                    else
                    {
                        rdr.Close();
                        SqlCommand cmd = new SqlCommand(String.Format("DELETE FROM cars_owned WHERE person_id = {0} AND car_model = '{1}' and cars_owned_id={2};", person_id, car.CarModel, car.CarsOwnedId), con);
                        await Task.Run(() => cmd.ExecuteNonQuery());
                        con.Close();
                        return ("OK");
                    }
                }
                catch (Exception e)
                {
                    con.Close();
                    return e.ToString();
                }
            }

        }
    }
}
