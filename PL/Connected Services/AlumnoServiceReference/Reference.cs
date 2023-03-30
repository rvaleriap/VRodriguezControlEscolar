﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PL.AlumnoServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="AlumnoServiceReference.IAlumno")]
    public interface IAlumno {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumno/Add", ReplyAction="http://tempuri.org/IAlumno/AddResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Result))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Alumno))]
        ML.Result Add(ML.Alumno alumno);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumno/Add", ReplyAction="http://tempuri.org/IAlumno/AddResponse")]
        System.Threading.Tasks.Task<ML.Result> AddAsync(ML.Alumno alumno);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumno/GetAll", ReplyAction="http://tempuri.org/IAlumno/GetAllResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Alumno))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        ML.Result GetAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumno/GetAll", ReplyAction="http://tempuri.org/IAlumno/GetAllResponse")]
        System.Threading.Tasks.Task<ML.Result> GetAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumno/GetById", ReplyAction="http://tempuri.org/IAlumno/GetByIdResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Alumno))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        ML.Result GetById(int IdAlumno);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumno/GetById", ReplyAction="http://tempuri.org/IAlumno/GetByIdResponse")]
        System.Threading.Tasks.Task<ML.Result> GetByIdAsync(int IdAlumno);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumno/DeleteEF", ReplyAction="http://tempuri.org/IAlumno/DeleteEFResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Result))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Alumno))]
        ML.Result DeleteEF(ML.Alumno alumno);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAlumno/DeleteEF", ReplyAction="http://tempuri.org/IAlumno/DeleteEFResponse")]
        System.Threading.Tasks.Task<ML.Result> DeleteEFAsync(ML.Alumno alumno);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAlumnoChannel : PL.AlumnoServiceReference.IAlumno, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AlumnoClient : System.ServiceModel.ClientBase<PL.AlumnoServiceReference.IAlumno>, PL.AlumnoServiceReference.IAlumno {
        
        public AlumnoClient() {
        }
        
        public AlumnoClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AlumnoClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AlumnoClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AlumnoClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ML.Result Add(ML.Alumno alumno) {
            return base.Channel.Add(alumno);
        }
        
        public System.Threading.Tasks.Task<ML.Result> AddAsync(ML.Alumno alumno) {
            return base.Channel.AddAsync(alumno);
        }
        
        public ML.Result GetAll() {
            return base.Channel.GetAll();
        }
        
        public System.Threading.Tasks.Task<ML.Result> GetAllAsync() {
            return base.Channel.GetAllAsync();
        }
        
        public ML.Result GetById(int IdAlumno) {
            return base.Channel.GetById(IdAlumno);
        }
        
        public System.Threading.Tasks.Task<ML.Result> GetByIdAsync(int IdAlumno) {
            return base.Channel.GetByIdAsync(IdAlumno);
        }
        
        public ML.Result DeleteEF(ML.Alumno alumno) {
            return base.Channel.DeleteEF(alumno);
        }
        
        public System.Threading.Tasks.Task<ML.Result> DeleteEFAsync(ML.Alumno alumno) {
            return base.Channel.DeleteEFAsync(alumno);
        }
    }
}
