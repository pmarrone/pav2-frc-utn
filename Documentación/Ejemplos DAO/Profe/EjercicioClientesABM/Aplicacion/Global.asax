﻿<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        Application["contador"] = 0;

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        Application.Lock();
        int i = Int32.Parse(Application["contador"].ToString());
        i++;
        Application["contador"] = i;
        Application.UnLock();
    }

    void Session_End(object sender, EventArgs e) 
    {
        Application.Lock();
        int i = Int32.Parse(Application["contador"].ToString());
        i--;
        Application["contador"] = i;
        Application.UnLock();

    }
       
</script>
