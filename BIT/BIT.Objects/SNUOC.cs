﻿
// =============================================
// This class is generated by BuildProject 
// Author:	Bop
// Create date:	17/08/2016 11:31
// Description:	
// Revise History:	
// =============================================
using System;

namespace BIT.Objects
{
    public class SNUOC
    {

        public int ID { get; set; }

        public string CODE { get; set; }

        public string NAME { get; set; }

    }

    public class SPACKAGE
    {
        public int ID { get; set; }

        public int PackageID { get; set; }

        public decimal PINAmount { get; set; }

        public string PackageName {get;set;}
    }

    public class PACKAGE_TRANSACTION
    {
        public int ID { get; set; }
           public string CODEID  {get;set;}
           public int PACKAGEID  {get;set;}
           public DateTime START_DATE  {get;set;}
           public DateTime END_DATE  {get;set;}
           public int EXPIRED  {get;set;}
           public DateTime GH1  {get;set;}
           public DateTime GH2  {get;set;}
           public int STATUS_GH  {get;set;}
           public DateTime CREATE_DATE  {get;set;}
           public string TRANSACTION_PACKAGE  {get;set;}
           public decimal AMOUNT  {get;set;}
           public int STATUS_PH  {get;set;}

           public string USERNAME { get;set;}
    }
}


