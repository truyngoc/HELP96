﻿
// =============================================
// This class is generated by BuildProject 
// Author:	Bop
// Create date:	14/08/2016 23:47
// Description:	
// Revise History:	
// =============================================
using System;
using System.Collections.Generic;

namespace BIT.Objects
{
    public class MEMBERS
    {

        public string CodeId { get; set; }
        //[Username]			[varchar](50) NOT NULL,
        public string Username { get; set; }
        //[Password]			[varchar](50) NOT NULL,
        public string Password { get; set; }
        //[CodeId_Sponsor]		[varchar](50) NULL,
        public string CodeId_Sponsor { get; set; }
        public string Password_PIN { get; set; }
        //[Password_PIN]		[varchar](50) NOT NULL,
        //[Fullname]			[nvarchar](250) NULL,
        public string Fullname { get; set; }
        //[Phone]				[varchar](50) NOT NULL,
        public string Phone { get; set; }
        //[Email]			[varchar](100) NULL,
        public string Email { get; set; }

        //[Wallet]			[nvarchar](250) NULL,
        public string Wallet { get; set; }
        //[CreateDate]			[datetime] NULL,
        public DateTime? CreateDate { get; set; }
        //[ID]			[int] IDENTITY(1,1) NOT NULL,
        public int ID { get; set; }
        //[Level]			[varchar](50) NOT NULL,
        public string Level { get; set; }
        //[ExistsChild] [bit] NOT NULL,
        public bool ExistsChild { get; set; }
        public int Status { get; set; }
        //[Status] [int] NOT NULL,
        //[Country] [nvarchar](250) NULL,
        public string Country { get; set; }
        //[ActiveDate] [datetime] NULL,
        public DateTime ActiveDate { get; set; }
        //[ExpiredDate] [datetime] NULL,
        public DateTime ExpiredDate { get; set; }
        public int? IsLock { get; set; }

        public string Upline { get; set; }

    }

    public class MEMBERS_EDIT
    {

        public string CodeId { get; set; }
        //[Username]			[varchar](50) NOT NULL,
        public string Username { get; set; }
        //[Password]			[varchar](50) NOT NULL,
        public string Upline { get; set; }
        //[Password]			[varchar](50) NOT NULL,
        public string Fullname { get; set; }
        //[Phone]				[varchar](50) NOT NULL,
        public string Phone { get; set; }
        //[Email]			[varchar](100) NULL,
        public string Email { get; set; }

        //[Wallet]			[nvarchar](250) NULL,
        public string Wallet { get; set; }
        public string WALLET_ADMIN { get; set; }
        public string Transaction { get; set; }
        //[CreateDate]			[datetime] NULL,
        public DateTime? CreateDate { get; set; }
        //[ID]			[int] IDENTITY(1,1) NOT NULL,
        public int ID { get; set; }
        //[Level]			[varchar](50) NOT NULL,
        
        public int STA { get; set; }
        
    }

    public class MemberTree
    {
        public string CodeId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string CodeId_Sponsor { get; set; }
        public string Password_PIN { get; set; }
        public string Fullname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Wallet { get; set; }
        public DateTime? CreateDate { get; set; }
        public int ID { get; set; }
        public string Level { get; set; }
        public bool ExistsChild { get; set; }
        public int Status { get; set; }
        public string Country { get; set; }
        public DateTime ActiveDate { get; set; }
        public DateTime ExpiredDate { get; set; }
        public int? IsLock { get; set; }

        public string Upline { get; set; }

        public List<MemberTree> Childens { get; set; }


        public MemberTree()
        {
            this.Childens = new List<MemberTree>();
        }
        public MemberTree(MEMBERS _mInfo)
        {
            this.CodeId = _mInfo.CodeId;
            this.Username = _mInfo.Username;
            this.Password = _mInfo.Password;
            this.CodeId_Sponsor = _mInfo.CodeId_Sponsor;
            this.Password_PIN = _mInfo.Password_PIN;
            this.Fullname = _mInfo.Fullname;
            this.Phone = _mInfo.Phone;
            this.Email = _mInfo.Email;
            this.Wallet = _mInfo.Wallet;
            this.CreateDate = _mInfo.CreateDate;
            this.ID = _mInfo.ID;
            this.Level = _mInfo.Level;
            this.ExistsChild = _mInfo.ExistsChild;
            this.IsLock = _mInfo.IsLock;
            this.Childens = new List<MemberTree>();
        }

    }
}


