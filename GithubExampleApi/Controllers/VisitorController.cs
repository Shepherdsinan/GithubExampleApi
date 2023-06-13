using GithubExampleApi.DAL.Context;
using GithubExampleApi.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GithubExampleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {


        [HttpGet]
        public IActionResult VisisorList()
        {
            using (var _visitorContext = new VisitorContext())
            {
                var values = _visitorContext.Visitors.ToList();
                return Ok(values);
            }

        }

        [HttpPost]
        public IActionResult VisitorAdd(Visitor visitor)
        {
            using (var _visitorContext = new VisitorContext())
            {
                _visitorContext.Add(visitor);
                _visitorContext.SaveChanges();
                return Ok();
            }
        }

        [HttpGet("{id}")]
        public IActionResult VisitorGet(int id)
        {
            using (var _visitorContext = new VisitorContext())
            {
                var values = _visitorContext.Visitors.Find(id);
                if (values == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(values);
                }
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVisitor(int id)
        {
            using (var _visitorContext = new VisitorContext())
            {
                var values = _visitorContext.Visitors.Find(id);
                if (values == null)
                {
                    return NotFound();
                }
                else
                {
                    _visitorContext.Remove(values);
                    _visitorContext.SaveChanges();
                    return Ok();
                }
            }
        }

        [HttpPut]
        public IActionResult UpdateVisitor(Visitor visitor)
        {
            using (var _visitorContext = new VisitorContext())
            {
                var values = _visitorContext.Find<Visitor>(visitor.VisitorID);
                if (values == null)
                {
                    return NotFound();
                }
                else
                {
                    values.Name = visitor.Name;
                    values.Surname = visitor.Surname;
                    values.City = visitor.City;
                    values.Country = visitor.Country;
                    values.Mail = visitor.Mail;
                    _visitorContext.Update(values);
                    _visitorContext.SaveChanges();
                    return Ok();
                }
            }
        }
    }
}