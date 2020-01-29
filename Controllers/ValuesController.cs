using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using WordProcessorLib;

namespace DOCHTMLConverter.Controllers
{
    public class ValuesController : ApiController
    {
        [Route("~/api/Upload")]
        [HttpPost]
        public HttpResponseMessage Upload()
        {
            WordProcessor wd = new WordProcessor();
            FileContent filecpntent=new FileContent();
           // HttpResponseMessage result = null;
            //var content = new MultipartContent();
            if (HttpContext.Current.Request.Files.Count > 0)
            {
              
                foreach (string file in HttpContext.Current.Request.Files)
                {
                    var postedFile = HttpContext.Current.Request.Files[file];
                    object fileSavePath = HttpContext.Current.Server.MapPath("~/") + HttpContext.Current.Request.Files[file].FileName;
                    filecpntent = wd.WordToHTML(postedFile, fileSavePath);
                    //return Request.CreateResponse(HttpStatusCode.OK, filecpntent, new MediaTypeHeaderValue("application/json"));
                  

                }
                    

            }

            return Request.CreateResponse(HttpStatusCode.OK, filecpntent);

        }
    }


}
