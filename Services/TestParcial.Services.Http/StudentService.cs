using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestParcial.Business;
using TestParcial.Entities;
using TestParcial.Services.Contracts;

namespace TestParcial.Services.Http
{
    [RoutePrefix("rest/Student")]
    public class StudentService : ApiController
    {
        [HttpPost]
        [Route("Add")]
        public Student Add(Student Student)
        {
            try
            {
                var bc = new StudentBusiness();
                return bc.Add(Student);
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };

                throw new HttpResponseException(httpError);
            }
        }

        [HttpGet]
        [Route("All")]
        public AllResponse All()
        {
            try
            {
                var response = new AllResponse();
                var bc = new StudentBusiness();
                response.Result = bc.All();
                return response;
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };

                throw new HttpResponseException(httpError);
            }
        }
    }
}

