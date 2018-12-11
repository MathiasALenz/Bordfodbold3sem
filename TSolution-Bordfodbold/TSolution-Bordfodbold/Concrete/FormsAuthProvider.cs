using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TSolution_Bordfodbold.Abstract;
using System.Web.Security;

namespace TSolution_Bordfodbold.Concrete {
  public class FormsAuthProvider : IAuthProvider {

    public bool Authenticate(string brugernavn, string kodeord) {
      bool result = FormsAuthentication.Authenticate(brugernavn, kodeord);

      if (result) {
        FormsAuthentication.SetAuthCookie(brugernavn, false);
      }
      return result;
    }
  }
}