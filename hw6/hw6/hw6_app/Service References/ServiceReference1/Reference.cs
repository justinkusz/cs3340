﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace hw6_app.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.DataParserService")]
    public interface DataParserService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DataParserService/ParseData", ReplyAction="http://tempuri.org/DataParserService/ParseDataResponse")]
        double[] ParseData(string data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DataParserService/ParseData", ReplyAction="http://tempuri.org/DataParserService/ParseDataResponse")]
        System.Threading.Tasks.Task<double[]> ParseDataAsync(string data);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface DataParserServiceChannel : hw6_app.ServiceReference1.DataParserService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DataParserServiceClient : System.ServiceModel.ClientBase<hw6_app.ServiceReference1.DataParserService>, hw6_app.ServiceReference1.DataParserService {
        
        public DataParserServiceClient() {
        }
        
        public DataParserServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DataParserServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DataParserServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DataParserServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public double[] ParseData(string data) {
            return base.Channel.ParseData(data);
        }
        
        public System.Threading.Tasks.Task<double[]> ParseDataAsync(string data) {
            return base.Channel.ParseDataAsync(data);
        }
    }
}