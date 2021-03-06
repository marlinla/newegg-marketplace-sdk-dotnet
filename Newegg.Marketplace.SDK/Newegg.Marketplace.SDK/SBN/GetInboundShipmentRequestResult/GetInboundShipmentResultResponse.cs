﻿/**
Newegg Marketplace SDK Copyright © 2000-present Newegg Inc. 

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
documentation files (the “Software”), to deal in the Software without restriction, including without limitation the 
rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software,
and to permit persons to whom the Software is furnished to do so, subject to the following conditions: 
The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software. 
THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR 
PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS 
BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, 
TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE
OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
**/
using System.Collections.Generic;
using System.Xml.Serialization;

using Newtonsoft.Json;

using Newegg.Marketplace.SDK.Base.Util;
using Newegg.Marketplace.SDK.Model;

namespace Newegg.Marketplace.SDK.SBN.Model
{
  
    [XmlRoot("NeweggAPIResponse")]
    public class GetInboundShipmentResultResponse : ResponseModel<GetInboundShipmentResultResponseBody>
    {
       
        public GetInboundShipmentResultResponse()
        {
            OperationType = "GetShipmentResultResponse";
        }
    }

    public class GetInboundShipmentResultResponseBody
    {
        public string RequestID { get; set; }
        public string RequestDate { get; set; }
        public string ProcessedDate { get; set; }
        public string RequestStatus { get; set; }
        public Shipment Shipment { get; set; }
    }

    public class Shipment
    {
        public string ShipmentID { get; set; }

        [XmlArrayItem(ElementName = "Label"), JsonConverter(typeof(JsonMoreLevelSeConverter), "Label")]
        public List<Label> LabelURLList { get; set; }

        [XmlArrayItem(ElementName = "Error"), JsonConverter(typeof(JsonMoreLevelSeConverter), "Error")]
        public List<Error> ErrorList { get; set; }

        public Shipment()
        {
            LabelURLList = new List<Label>();
            ErrorList = new List<Error>();
        }
    }

    public class Label
    {
        public string LabelType { get; set; }
        public string LabelUrl { get; set; }
    }

    public class Error
    {
        public string ErrorDescription { get; set; }
    }
}
