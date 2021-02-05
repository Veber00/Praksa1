using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using dan03.Models;

namespace dan03.Controllers
{
    public class CarOwnersController : ApiController
    {

        SqlConnection con = new SqlConnection("data source=.; database=master; integrated security=SSPI");


        [HttpGet]
        [Route("api/GetAll")]
        public HttpResponseMessage GetAll()
        {

            List<string> ret = new List<string>();

            using (con)
            {

                SqlCommand cmd = new SqlCommand("SELECT * FROM person", con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        ret.Add(rdr.GetInt32(0) + " " + rdr.GetString(1) + " " + rdr.GetInt32(2));
                    }

                    con.Close();
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Table is empty.");
                }


                return Request.CreateResponse(HttpStatusCode.OK, ret);

            }
        }




        [HttpGet]
        [Route("api/GetPersonCar/{id}")]
        public HttpResponseMessage GetPersonCar(int id)
        {

            List<string> ret = new List<string>();

            using (con)
            {

                SqlCommand cmd = new SqlCommand(String.Format("SELECT car_model, car_year FROM cars_owned " + "where person_id={0}", id), con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        ret.Add(rdr.GetString(0) + " " + rdr.GetInt32(1));
                    }
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "This person doesn't have a car.");
                }
                con.Close();


                return Request.CreateResponse(HttpStatusCode.OK, ret);
            }
        }

        [HttpPost]
        [Route("api/NewPerson")]
        public HttpResponseMessage NewPerson([FromBody] Person value)
        {

            using (con)
            {
                SqlCommand cmd = new SqlCommand(String.Format("INSERT INTO person (person_id, full_name, age) VALUES ({0}, '{1}', {2})", value.PersonId, value.Fullname, value.Age), con);

                con.Open();

                cmd.ExecuteNonQuery();

            }

            con.Close();

            return Request.CreateResponse(HttpStatusCode.Accepted, "New Person inserted.");

        }

        [HttpPut]
        [Route("api/UpdateCar/{person_id}")]
        public HttpResponseMessage UpdateCar(int person_id, [FromBody] Car value)
        {

            using (con)
            {
                SqlCommand cmd = new SqlCommand(String.Format("UPDATE cars_owned SET car_millage = {0} WHERE person_id={1} and car_model='{2}'", value.CarMillage, person_id, value.CarModel), con);

                con.Open();

                cmd.ExecuteNonQuery();
            }

            con.Close();

            return Request.CreateResponse(HttpStatusCode.Accepted, "Millage updated.");

        }

        [HttpDelete]
        [Route("api/DeleteCar/{person_id}")]
        public HttpResponseMessage DeleteCar(int person_id, [FromBody] Car value)
        {

            using (con)
            {
                SqlCommand cmd = new SqlCommand(String.Format("DELETE FROM cars_owned WHERE person_id = {0} AND car_model = '{1}';", person_id, value.CarModel), con);

                con.Open();

                cmd.ExecuteNonQuery();
            }

            con.Close();

            return Request.CreateResponse(HttpStatusCode.Accepted, String.Format("Car deleted.{0},{1}", person_id, value.CarModel));

        }


    }
}
