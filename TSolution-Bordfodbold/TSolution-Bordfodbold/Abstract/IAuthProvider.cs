using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSolution_Bordfodbold.Abstract {
  public interface IAuthProvider {
    bool Authenticate(string brugernavn, string kodeord);
  }
}
