using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Carter;
using Microsoft.AspNetCore.Http;

namespace Exercises.Pages.Lesson0
{
    public class Exercises : CarterModule
    {
        public Exercises()
        {
            Get("/Lesson0/assignment0", Assignment0);

            Get("/Lesson0/assignment1", Assignment1);

            Get("/Lesson0/assignment2", Assignment2);

            Get("/Lesson0/assignment3", Assignment3);

            Get("/Lesson0/assignment4", Assignment4);

            Get("/Lesson0/assignment5", Assignment5Get);

            Post("/Lesson0/assignment5", Assignment5Post);

            //Get("/Lesson1/assignment6", Assignment6Get);
        }

        private Task Assignment0(HttpRequest request, HttpResponse response)
        {
            response.StatusCode = StatusCodes.Status200OK;
            response.ContentType = "text/html";

            string content = "Hello World";

            return response.WriteAsync(content);

            //return Task.CompletedTask;
        }

        private Task Assignment1(HttpRequest request, HttpResponse response)
        {
            response.StatusCode = StatusCodes.Status200OK;
            response.ContentType = "text/html";

            string content = "<h1>Hello World</h1>";

            return response.WriteAsync(content);

            //return Task.CompletedTask;
        }

        private Task Assignment2(HttpRequest request, HttpResponse response)
        {
            string content;
            content = "<h1>Bad request</h1>";
            response.StatusCode = StatusCodes.Status400BadRequest;

            response.ContentType = "text/html";
            if (request.QueryString.HasValue && !string.IsNullOrWhiteSpace(request.QueryString.Value.Split("=")[1]))
            {
                response.StatusCode = StatusCodes.Status200OK;
                content = "<h1>" + request.QueryString.Value.Split("=")[1] + "</h1>";
            }

            return response.WriteAsync(content);

            //return Task.CompletedTask;
        }

        private Task Assignment3(HttpRequest request, HttpResponse response)
        {
            string content;
            content = "<h1>Bad request</h1>";
            response.StatusCode = StatusCodes.Status400BadRequest;

            response.ContentType = "text/html";
            if (request.QueryString.HasValue && request.Query.ContainsKey("firstname") && request.Query.ContainsKey("lastname") && request.Query.ContainsKey("age"))
            {
                response.StatusCode = StatusCodes.Status200OK;
                content = "<ul>Leeftijd: " + request.Query["age"] + " van<li>" + request.Query["firstname"] + "</li><li>" + request.Query["lastname"] + "</li></ul>";
            }

            return response.WriteAsync(content);

            //return Task.CompletedTask;
        }

        private Task Assignment4(HttpRequest request, HttpResponse response)
        {
            string content;
            content = "<h1>Bad request</h1>";
            response.StatusCode = StatusCodes.Status400BadRequest;

            response.ContentType = "text/html";
            if (request.QueryString.HasValue && !string.IsNullOrWhiteSpace(request.QueryString.Value.Split("=")[1]))
            {
                response.StatusCode = StatusCodes.Status200OK;
                content = "<h1>" + WebUtility.HtmlEncode(request.QueryString.Value.Split("=")[1]) + "</h1>";
            }

            return response.WriteAsync(content);

            //return Task.CompletedTask;
        }

        private Task Assignment5Get(HttpRequest request, HttpResponse response)
        {
            response.StatusCode = StatusCodes.Status200OK;
            response.ContentType = "text/html";

            response.WriteAsync(FormAssignment5());

            return response.CompleteAsync();

            //return Task.CompletedTask;
        }

        private Task Assignment5Post(HttpRequest request, HttpResponse response)
        {
            response.StatusCode = StatusCodes.Status200OK;
            response.ContentType = "text/html";

            string firstname = string.Empty;
            string lastname = string.Empty;
            string age = string.Empty;
            string firstNameError = string.Empty;
            string lastNameError = string.Empty;
            string ageError = string.Empty;

            firstname = request.Form["firstname"].First();
            lastname = request.Form["lastname"].First();
            age = request.Form["age"].First();
            if (request.Form.ContainsKey("firstname") && string.IsNullOrWhiteSpace(request.Form["firstname"]) && request.Form["firstname"].Count > 2)
                firstNameError = "Voornaam moet minimaal 2 of meer karakters hebben";
            if (request.Form.ContainsKey("lastname") && string.IsNullOrWhiteSpace(request.Form["lastname"]) && request.Form["lastname"].Count > 2)
                lastNameError = "Achternaam moet minimaal 2 of meer karakters hebben";
            if (request.Form.ContainsKey("age") && string.IsNullOrWhiteSpace(request.Form["age"]) && int.TryParse(request.Form["age"], out int ageConverted))
                ageError = "Leeftijd moet een heel getal zijn";

            string form = FormAssignment5(firstname, lastname, age, firstNameError, lastNameError, ageError);

            string displayResponse = $@"
                <h1>{firstname} {lastname} is {age} jaren oud</h1>
            ";

            response.WriteAsync(form + displayResponse);

            return response.CompleteAsync();
        }

        private string FormAssignment5(string firstName = "", string lastName = "", string age = "",
            string firstNameError = "",
            string lastNameError = "", string ageError = "")
        {
            //throw new NotImplementedException();

            var form = $@"
                <form method='post'>
                    Name: <input type='text' name='firstname' value='{firstName}'><br>
                    Lastname: <input type='text' name='lastname' value='{lastName}'><br>
                    Age: <input type='text' name='age' value='{age}'><br>
                    <input type='submit'>
                </form>";
            return form;
        }

        // private Task Assignment6Get(HttpRequest request, HttpResponse response)
        // {
        //
        // }


    }
}
