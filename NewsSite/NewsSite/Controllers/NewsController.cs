using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using System.Web.Http.OData.Routing;
using DomainObjects;
using Microsoft.Data.OData;
using Service;

namespace NewsSite.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using DomainObjects;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<News>("News");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class NewsController : ODataController
    {
        private static ODataValidationSettings _validationSettings = new ODataValidationSettings();

        DataService service = new DataService();

        [EnableQuery]
        // GET: odata/News
        public IHttpActionResult GetNews(ODataQueryOptions<News> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(service.GetAllNews().AsQueryable());
            //return StatusCode(HttpStatusCode.NotImplemented);
        }

        // GET: odata/News(5)
        public IHttpActionResult GetNews([FromODataUri] int key, ODataQueryOptions<News> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            // return Ok<News>(news);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PUT: odata/News(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<News> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Put(news);

            // TODO: Save the patched entity.

            // return Updated(news);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // POST: odata/News
        public IHttpActionResult Post(News news)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Add create logic here.

            // return Created(news);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PATCH: odata/News(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<News> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Patch(news);

            // TODO: Save the patched entity.

            // return Updated(news);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // DELETE: odata/News(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            // TODO: Add delete logic here.

            // return StatusCode(HttpStatusCode.NoContent);
            return StatusCode(HttpStatusCode.NotImplemented);
        }
    }
}
