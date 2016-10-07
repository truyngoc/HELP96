<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="_Alerts.ascx.cs" Inherits="BIT.WebUI.Admin._Alerts" %>

<%@ Import Namespace="TNotify" %>

<%
    
    var alerts = System.Web.HttpContext.Current.Session[Alert.TempDataKey] != null
                ? (List<Alert>)System.Web.HttpContext.Current.Session[Alert.TempDataKey] : new List<Alert>();

    System.Web.HttpContext.Current.Session.Remove(Alert.TempDataKey);

    if (alerts.Any())
    {            
%>
<br />
<% }

    foreach (var alert in alerts)
    {
        var dismissableClass = alert.Dismissable ? "alert-dismissable" : null;

%>
<div class="alert alert-<%= alert.AlertStyle %> <%= dismissableClass %>">

    <%     if (alert.Dismissable)
           {
    %>
    <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
    <%
           }
           
    %>

    <%= HttpUtility.HtmlDecode(Server.HtmlDecode(alert.Message)) %>
</div>
<%
    }
%>