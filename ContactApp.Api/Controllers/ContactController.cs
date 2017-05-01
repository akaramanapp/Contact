using ContactApp.Api.Infrastructure;
using ContactApp.Business.Abstract;
using ContactApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ContactApp.Api.Controllers
{
    public class ContactController : ApiController
    {
        private IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        [Authorize]
        public IEnumerable<Contact> GetAllContact()
        {
            try
            {
                return _contactService.GetAll();
            }
            catch (Exception ex)
            {
                int _errorCode = System.Runtime.InteropServices.Marshal.GetExceptionCode();
                Publisher.SendMessage(new ErrorLog() { ErrorText = ex.Message, ErrorCode = _errorCode, Platform = "Web", CreatedDate = DateTime.Now, });
            }
            return _contactService.GetAll();
        }

        [Authorize]
        public HttpResponseMessage Post(Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _contactService.Add(contact);
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, contact);
                    return response;
                }
                catch (System.Exception ex)
                {
                    int _errorCode = System.Runtime.InteropServices.Marshal.GetExceptionCode();
                    Publisher.SendMessage(new ErrorLog() { ErrorText = ex.Message, ErrorCode = _errorCode, Platform = "Web", CreatedDate = DateTime.Now, });
                }
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [HttpGet]
        [Route("api/contact/GetContact/{contactId}")]
        [Authorize]
        public Contact GetContact(int contactId)
        {
            try
            {
                return _contactService.Get(contactId);
            }
            catch (Exception ex)
            {
                int _errorCode = System.Runtime.InteropServices.Marshal.GetExceptionCode();
                Publisher.SendMessage(new ErrorLog() { ErrorText = ex.Message, ErrorCode = _errorCode, Platform = "Web", CreatedDate = DateTime.Now, });
            }
            return _contactService.Get(contactId);
        }

        [HttpPost]
        [Route("api/contact/Update")]
        [Authorize]
        public HttpResponseMessage Update(Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _contactService.Update(contact);
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, contact);
                    return response;
                }
                catch (System.Exception ex)
                {
                    int _errorCode = System.Runtime.InteropServices.Marshal.GetExceptionCode();
                    Publisher.SendMessage(new ErrorLog() { ErrorText = ex.Message, ErrorCode = _errorCode, Platform = "Web", CreatedDate = DateTime.Now, });
                }
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [HttpPost]
        [Route("api/contact/Delete")]
        [Authorize]
        public HttpResponseMessage Delete(Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _contactService.Delete(contact);
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, contact);
                    return response;
                }
                catch (System.Exception ex)
                {
                    int _errorCode = System.Runtime.InteropServices.Marshal.GetExceptionCode();
                    Publisher.SendMessage(new ErrorLog() { ErrorText = ex.Message, ErrorCode = _errorCode, Platform = "Web", CreatedDate = DateTime.Now, });
                }
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

    }
}
