<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="_Notify.ascx.cs" Inherits="BIT.WebUI.Admin._Notify" %>

<%@ Import Namespace="TNotify" %>


<%
    
    var notifys = System.Web.HttpContext.Current.Session[Notify.TempDataKey] != null
                ? (List<Notify>)System.Web.HttpContext.Current.Session[Notify.TempDataKey] : new List<Notify>();

    System.Web.HttpContext.Current.Session.Remove(Notify.TempDataKey);
        
%>

<script>    
    $(document).ready(function () {        
        <%     
    foreach (var n in notifys)
    {
        string notifytType = n.NotifyType.ToString("F").ToLower();
        string position = n.Position.ToString().Replace("_", "-");
        bool dismissable = n.Dismissable;
%>
        toastr.options.positionClass = "<%= position %>";
        toastr.options.closeButton = "<%= dismissable %>";
        toastr['<%= notifytType %>']('<%= n.Message %>', '<%= n.Title %>');
        <%
        } %>
    });
</script>
