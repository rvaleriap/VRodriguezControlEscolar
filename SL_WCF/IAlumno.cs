using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAlumno" in both code and config file together.
    [ServiceContract]
    public interface IAlumno
    {
        //Firma del método ADD
        [OperationContract]
        [ServiceKnownType(typeof(ML.Alumno))]
        ML.Result Add(ML.Alumno alumno);

        //Firma del método GetAll
        [OperationContract]
        [ServiceKnownType(typeof(ML.Alumno))]
        ML.Result GetAll();

        //Firma del método GetById
        [OperationContract]
        [ServiceKnownType(typeof(ML.Alumno))]
        ML.Result GetById(int IdAlumno);

        //Firma del método eliminar
        [OperationContract]
        [ServiceKnownType(typeof(ML.Alumno))]
        ML.Result DeleteEF(ML.Alumno alumno);
    }
}
