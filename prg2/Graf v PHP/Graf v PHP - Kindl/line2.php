 <?php 
$connect = mysqli_connect("sql5.webzdarma.cz", "pujcovnaaut36052", "a7pKc7plw7gl-z45lf),", "pujcovnaaut36052");
$query = "SELECT * FROM firma";
$result = mysqli_query($connect, $query,);
$chart_data = '';
while($row = mysqli_fetch_array($result))
{
 $chart_data .= "{ rok:'".$row["rok"]."', nakup:".$row["nakup"].", prodej:".$row["prodej"].", vydelek:".$row["vydelek"]."}, ";
}
$chart_data = substr($chart_data, 0, -2);
?>


<!DOCTYPE html>
<html>
 <head>
  <title>Graf ve firmě</title>
  <link rel="stylesheet" href="//cdnjs.cloudflare.com/ajax/libs/morris.js/0.5.1/morris.css">
  <script src="//ajax.googleapis.com/ajax/libs/jquery/1.9.0/jquery.min.js"></script>
  <script src="//cdnjs.cloudflare.com/ajax/libs/raphael/2.1.0/raphael-min.js"></script>
  <script src="//cdnjs.cloudflare.com/ajax/libs/morris.js/0.5.1/morris.min.js"></script>
  
 </head>
 <body>
  <br /><br />
  <div class="container" style="width:900px;">
   <h2 align="center">Graf výdajů/výdělků firmy</h2>
   <h3 align="center">x- roky, y- penize</h3>   
   <br /><br />
   <div id="chart"></div>
  </div>
 </body>
</html>

<script>
Morris.Line({
 element : 'chart',
 data:[<?php echo $chart_data; ?>],
 xkey:'rok',
 ykeys:['nakup','prodej', 'vydelek'],
 labels:['nakup','prodej', 'vydelek'],
 hideHover:'auto',
});
</script>