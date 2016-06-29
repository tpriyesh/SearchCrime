using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;


namespace NationalCrime.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface INationalCrimeService
    {

       
        [OperationContract]
        bool ValidateLogin(string username,string password);

        [OperationContract]
        string Register(string username,string email,string password);

        [OperationContract]
        int SearchCriminal(string name, string nationality, string gender, float startheight, float endheight, float startweight, float endweight, int startage, int endage,string email);
       

    }


}
