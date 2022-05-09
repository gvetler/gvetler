<?php 

	include_once('../config.php');
	$db = new Database();

?>

<!DOCTYPE html>
<html lang="">
	<head>
		<meta charset="utf-8">
		<meta http-equiv="X-UA-Compatible" content="IE=edge">
		<meta name="viewport" content="width=device-width, initial-scale=1">
		<title>Rezervace sluzeb</title>

		
		<link rel="stylesheet" type="text/css" href="../bootstrap/css/bootstrap.css">
		<link rel="stylesheet" type="text/css" href="../bootstrap/css/jquery.dataTables.css">

	
	    
	    <script src="../bootstrap/	js/jquery.dataTables2.js"></script>


	</head>

	<style type="text/css">
		.navbar { margin-bottom:0px !important; }
		.carousel-caption { margin-top:0px !important }

		td.align-img {
			line-height: 3 !important;
		}
	</style>

	<body>

		
			<nav class="navbar navbar-default navbar-fixed-top" role="navigation">
				<div class="container-fluid">
					
					<div class="navbar-header">
						<button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-ex1-collapse">
							<span class="sr-only">Toggle navigation</span>
							<span class="icon-bar"></span>
							<span class="icon-bar"></span>
							<span class="icon-bar"></span>
						</button>
						<img src="../img/logo.png" height="50" width="80"> &nbsp;
					</div>
			
					
					<div class="collapse navbar-collapse navbar-ex1-collapse">
						<ul class="nav navbar-nav">
							<li><a href="#" style="font-family: Times New Roman; font-size: 30px;">Rezervace sluzeb</a></li>
						</ul>

						<ul class="nav navbar-nav" style="font-family: Times New Roman;">
							<li>
								<a href="index.php">Sluzby</a>
							</li>
							<li  class="active">
								<a href="myreservation.php">Moje rezervace</a>
							</li>
						</ul>
						
						<ul class="nav navbar-nav navbar-right" style="font-family: Times New Roman;">
							<li>
								<?php include_once('../includes/logout.php'); ?>
							</li>
						
						</ul>
					</div>
				</div>
			</nav>
	

		<br />
		<br />
		<br />
		<br />
		

		
		
 <div class="container">
			
			<br />
			<br />

			<?php
	
			if(isset($_GET['delr_id']))
				{
					$delrid = $_GET['delr_id'];
					$tid = $_SESSION['tourID'];

					$sql = "DELETE FROM reservation WHERE u_id = ? AND r_id = ?";
					$res = $db->deleteRow($sql, [$tid, $delrid]);

						echo '
								<div class="alert alert-success">
								  <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
								  <strong>Success!</strong> Zrušení rezervace bylo uspesne.
								</div>
							';
							
				}
		 ?>

		 <br />
		 	 <table id="myTable" class="table table-striped" >  
				<thead>
					<th><center>Obrazek</center></th>
					<th>Nazev sluzby</th>	
					<th>Email</th>
					<th>Datum</th>
					<th>Cas</th>
					<th>Cena</th>
					<th><center>Akce</center></th>
				</thead>
				<tbody>
					<?php 
			$tid = $_SESSION['tourID'];
			$sql = "SELECT * FROM reservation r INNER JOIN sluzby b ON b.b_id = r.b_id
			INNER JOIN uzivatele t ON t.u_id = r.u_id
			WHERE t.u_id = ? ";
			$res = $db->getRows($sql, [$tid]);



			foreach ($res as  $r) {

				$r_id = $r['r_id'];
				$img = $r['s_img'];
				$bn = $r['s_nazev'];	
				$email = $r['r_email'];
				$bprice = $r['s_cena'];
				$rdate = $r['r_datum'];
				$rhr = $r['r_cas'];
				$rampm = $r['r_ampm'];

				$oras = $rhr.' '.$rampm;
		?>
					<tr>
						<td class="align-img"><center><img src="<?php echo $img; ?>" width="50" height="50"></center></td>
						<td class="align-img"><?php echo $bn; ?></td>
						<td class="align-img"><?php echo $email; ?></td>
						<td class="align-img"><?php echo $rdate; ?></td>
						<td class="align-img"><?php echo $oras; ?></td>
						<td class="align-img"><?php echo 'CZK '.number_format($bprice, 2); ?></td>
						<td class="align-img">
							<a class = "btn btn-danger  btn-xs" href="myreservation.php?delr_id=<?php echo $r_id; ?>">
								Cancel
								
							</a>
						</td>
					</tr>
					<?php
			}


		?>



				</tbody>
			</table>

		 </div>

			
		

	</body>
 		<script src="../bootstrap/js/jquery-1.11.1.min.js"></script>
 		<script src="../bootstrap/js/dataTables.js"></script>
 		<script src="../bootstrap/js/dataTables2.js"></script>
 		<script src="../bootstrap/js/bootstrap.js"></script>
 		 
    <link rel="stylesheet" href="../bootstrap/css/jquery.dataTables.css">
    <script src="../bootstrap/js/jquery.dataTables2.js"></script>


    <script>

$(document).ready(function(){
    $('#myTable').dataTable();
});
    </script>


		
		

	</body>
 		<script src="../bootstrap/js/jquery-1.11.1.min.js"></script>
 		<script src="../bootstrap/js/dataTables.js"></script>
 		<script src="../bootstrap/js/dataTables2.js"></script>
 		<script src="../bootstrap/js/bootstrap.js"></script>
 		    
    <link rel="stylesheet" href="../bootstrap/css/jquery.dataTables.css">
    <script src="../bootstrap/js/jquery.dataTables2.js"></script>






</html>



<?php 
$db->Disconnect();
?>