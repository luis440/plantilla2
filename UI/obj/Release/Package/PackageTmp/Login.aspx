<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <link href="css/StyleLogin.css" rel="stylesheet" />
    <link href="css/login/bootstrap.min.css" rel="stylesheet" />
    <script src="js/Bootstrap/jquery-3.1.1.min.js"></script>
    <script src="js/Bootstrap/bootstrap.min.js"></script>

    <script src="js/Bootstrap/Js_Login.js"></script>
    <link href="js/sweetalert2-7.26.12/package/dist/sweetalert2.min.css" rel="stylesheet" />
    <script src="js/sweetalert2-7.26.12/package/dist/sweetalert2.min.js"></script>
    <script src="js/Bootstrap/jquery.session.js"></script>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
          .load {
    display: none;
    position: fixed;
    z-index: 9999;
    top: 0;
    left: 0;
    height: 100%;
    width: 100%;
    background: rgba( 0, 0, 0, 0.3 ) url(../img/cargando12.gif) 50% 50% no-repeat;
}

/* Cuando el body tiene la clase 'loading' ocultamos la barra de navegacion */
body.loading {
    overflow: hidden;
}

    /* Siempre que el body tenga la clase 'loading' mostramos el modal del loading */
    body.loading .load {
        display: block;
    }
    </style>
</head>
<body >
      
      <div class="load">
            </div>
 <div class="login-box">
    
    <img src="img/seguridad.gif" class="avatar"/>
     <br /><br />
        <%--<h1>Login Here</h1>--%>
     <div>
<img src="img/Logo_33.png"  class="img-responsive"  style=" border-radius: 2em;  "/>
     </div>
     

            <form>
            <p>Usuario</p>
            <input id="txtusuario" type="text" name="username" placeholder="Ingrese Usuario"/>
            <p>Contraseña</p>
            <input id="txtclave" type="password" name="password" placeholder="Ingrese Contraseña"/>
          <%--  <input type="submit" name="submit" value="Login"/>--%>
                
                    <button   id="btningresar" type="button"  class="form-control btn-default" style="background-color:#429596;color:white" ><b>Ingresar</b></button>
            <br />
                <a href="https://www.cybercodegroup.com" style="color:#429596">www.cybercodegroup.com</a>    
            </form>
        
        
        </div>
 
   
</body>
</html>
