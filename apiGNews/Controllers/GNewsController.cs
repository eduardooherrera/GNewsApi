using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using apiGNews.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apiGNews.Controllers
{
    [Route("api/[controller]")]
    public class GNewsController : Controller
    {
        // GET: api/values
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                Posts posts = new Posts();
                List<miniPost> miniPost = new List<miniPost>();
                var url = "https://gnews.io/api/v4/search?q=watches&token=cea4340922446f27a063dcae0c94bbec";
                using (var http = new HttpClient())
                {
                    var response = await http.GetStringAsync(url);
                    posts = JsonConvert.DeserializeObject<Posts>(response);
                    foreach (var item in posts.Post)
                    {
                        miniPost.Add(new Models.miniPost
                        {
                            Title = item.Title,
                            Description = item.Description,
                            hide = true,
                            Img = item.Image
                        });
                    }

                }
                return Ok(miniPost);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
