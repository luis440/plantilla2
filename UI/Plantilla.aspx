<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Plantilla.aspx.cs" Inherits="UI.Plantilla" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>

    <title>.::. Control de Salida .::.</title>

    <link href="css/bootstrap.min.css" rel="stylesheet"/>
    <link href="font-awesome/css/font-awesome.css" rel="stylesheet"/>

    <link href="css/animate.css" rel="stylesheet"/>
    <link href="css/style.css" rel="stylesheet"/>
</head>
<body>

    <div id="wrapper">

    <nav class="navbar-default navbar-static-side" role="navigation">
        <div class="sidebar-collapse">
          

        </div>
    </nav>

        <div id="page-wrapper" class="gray-bg" style="background:url('img/FONDO_COLEGIO2.png') no-repeat center center fixed; -webkit-background-size: cover;-moz-background-size: cover; -o-background-size: cover;background-size: cover;">
        <div class="row border-bottom" style="background-color:white">
      <nav class="navbar navbar-static-top" role="navigation" style="margin-bottom: 0">
        <div class="navbar-header">
            <a class="navbar-minimalize minimalize-styl-2 btn btn-primary " href="#"><i class="fa fa-bars"></i> </a>
            <form role="search" class="navbar-form-custom" action="search_results.html">
                <div class="form-group">
                    <input type="text" placeholder="Colegio Claretiano" class="form-control" name="top-search" id="top-search"/>
                </div>
            </form>
        </div>
            <ul class="nav navbar-top-links navbar-right">
                <li>
                    <span class="m-r-sm text-muted welcome-message">Colegio Claretiano</span>
                </li>
               

                <li>
                  <a><i class="fa fa-graduation-cap"></i> Colegio Claretiano</a>
                        
                   
                </li>
            </ul>

        </nav>

        </div>
           
        <div class="wrapper wrapper-content animated fadeInRight">
        <div class="row">
            <div class="col-lg-12" >
                <div class="contact-box center-version" style="text-align:center;padding-top:20px">

                   

                        <img id="img_alumno" alt="image" class="img-responsive"  style="height:200px;width:200px;border-radius:20%" />


                       <h2 class="m-b-xs" ><strong style="font-weight: bold; color: black;font-size: 18px" id="nombre_alumno"></strong></h2>
                        <h3 class="font-bold" id="codigo_alumno"></h3> 
                        <h3 class="font-bold" id="documento_alumno"></h3> 
                        <h3 class="font-bold" id="nivel_alumno"></h3>
                          <h3 class="font-bold" id="grado_alumno"></h3>
                        <h3 class="font-bold" id="seccion_alumno"></h3>
                        <%--<address class="m-t-md">
                            <strong>Twitter, Inc.</strong><br>
                            795 Folsom Ave, Suite 600<br>
                            San Francisco, CA 94107<br>
                            <abbr title="Phone">P:</abbr> (123) 456-7890
                        </address>--%>

                 
                    <div class="contact-box-footer">
                        <div class="m-t-xs btn-group">
                            <i class="fa fa-check" style="color: green">
                              <span style="font-weight: bold; color: black; font-size: 15px">Registrado Exitosamente</span></i>
                        </div>
                    </div>

                </div>
            </div>
     
        </div>
        </div>
 <div class="footer">
            <%--<div class="float-right">
                10GB of <strong>250GB</strong> Free.
            </div>--%>
            <div>
               <strong>Copyright</strong> LMQGroup &copy; 2020
            </div>
        </div>

        </div>
        </div>

    <!-- Mainly scripts -->
   <script src="../js/Bootstrap/jquery-3.1.1.min.js"></script>
    <script src="../js/Bootstrap/popper.min.js"></script>
    <script src="../js/Bootstrap/bootstrap.js"></script>
    <script src="../js/plugins/metisMenu/jquery.metisMenu.js"></script>
    <script src="../js/plugins/slimscroll/jquery.slimscroll.min.js"></script>


    <!-- Custom and plugin javascript -->
   <script src="../js/Bootstrap/inspinia.js"></script>
    <script src="../js/plugins/pace/pace.min.js"></script>
    <script src="js/Plantilla/Plantilla.js"></script>


</body>
</html>
