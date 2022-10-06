using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using TaskManager.Models;
using System.Data;
using Task = TaskManager.Models.Task;
using System.Diagnostics.Metrics;
using System.Threading.Tasks;

namespace TaskManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        SqlConnection connection = new SqlConnection();



        [HttpGet]
        public IEnumerable<Task> ListAllTasks()
        {
            var tasks = new List<Task>();
            string procedureName = "[dbo].[GetAllTasks]";
            //var result = new List<Tasks>();
            connection.ConnectionString =
                "Server=localhost;Database=TaskManagementSystem;integrated security=True;";
            using (SqlCommand command = new SqlCommand(procedureName,
            connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                //command.Parameters.Add(new SqlParameter("@Country", country));
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = Int32.Parse(reader[0]?.ToString());
                        int assignedTo = Int32.Parse(reader[1]?.ToString());
                        string taskStatusName = reader[2]?.ToString();
                        string taskTypeName = reader[3]?.ToString();
                        string commentText = reader[4]?.ToString();
                        string commentTypeName = reader[5]?.ToString();
                        string taskDescription = reader[6]?.ToString();
                        string assignedUserName = reader[7]?.ToString();
                        DateTime nextActionDate = DateTime.Parse(reader[8].ToString());


                        Task task = new Task()
                        {
                            TaskId = id,
                            AssignedTo = assignedTo,
                            TaskStatusName = taskStatusName,
                            TaskTypeName = taskTypeName,
                            TaskDescription = taskDescription,
                            NextActionDate = nextActionDate,
                            AssignedUserName = assignedUserName,
                            CommentText = commentText,
                            CommentTypeName = commentTypeName
                        };
                        tasks.Add(task);
                    }
                }

                return tasks;
            }



        }

        [HttpPost]
        //[Route("addTask")]
        public JsonResult AddTasks([FromBody] Task task)
        {
            string procedureName = "[dbo].[AddTask]";
            connection.ConnectionString = 
                "Server=localhost;Database=TaskManagementSystem;integrated security=True;";
            connection.Open();
            using (SqlCommand command = new SqlCommand(procedureName,
            connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@taskDescription", task.TaskDescription));
                command.Parameters.Add(new SqlParameter("@taskStatus", task.TaskDescription));
                command.Parameters.Add(new SqlParameter("@comment", task.TaskDescription));
                command.Parameters.Add(new SqlParameter("@createdDate", DateTime.UtcNow));
                command.Parameters.Add(new SqlParameter("@requiredBy", task.TaskDescription));
                command.Parameters.Add(new SqlParameter("@commentType", task.TaskDescription));
                command.Parameters.Add(new SqlParameter("@dateAdded", DateTime.UtcNow));
                command.Parameters.Add(new SqlParameter("@taskType", task.TaskType));
                command.Parameters.Add(new SqlParameter("@assignedTo", task.AssignedTo));
                command.Parameters.Add(new SqlParameter("@taskId", task.TaskId));



                command.ExecuteScalar();
            }
            return new JsonResult("Added successfully");
        }

        [HttpDelete]
        [Route("{id}")]
        public JsonResult DeleteTask(int taskId)
        {
            string procedureName = "[dbo].[DeleteById]";
            connection.ConnectionString = 
                "Server=localhost;Database=TaskManagementSystem;integrated security=True;";
            
            using (SqlCommand command = new SqlCommand(procedureName,
            connection))
            {
                connection.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@taskId", taskId));
            }
            return new JsonResult("Deleted record");
        }
    }
}
