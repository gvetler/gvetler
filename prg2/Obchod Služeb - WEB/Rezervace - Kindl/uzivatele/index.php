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

	</head>

	<style type="text/css">
		.navbar { margin-bottom:0px !important; }
		.carousel-caption { margin-top:0px !important }
	</style>


	<body>

		
			
			
					
					<div class="collapse navbar-collapse navbar-ex1-collapse">
						<ul class="nav navbar-nav">
							<li><a href="#" style="font-family: Times New Roman; font-size: 30px;">Rezervace sluzeb</a></li>
						</ul>

						<ul class="nav navbar-nav" style="font-family: Times New Roman;">
							
							<li>
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

		<div id ="info"  ></div>
	<div class="container-fluid">
			
		<div class="panel panel-info">
		  <div class="panel-heading">Nabidka sluzeb</div>
		  <div class="panel-body">
		  		<?php 
		  			$sql = 'SELECT * FROM sluzby ORDER by s_nazev';
		  		 	$res = $db->getRows($sql);
		  		 	
		  		 	if($res){
		  		 		foreach ($res as $r) {
		  		 			$b_id = $r['b_id'];
	  		 				$bName = $r['s_nazev'];
	  		 				$bCap = $r['s_popis'];
		  		 			$bImage = $r['s_img'];
	  		 				$bPrice = $r['s_cena'];

	  		 	?>	
	  		 		<a href="#"  data-toggle="modal" data-target="#myModal<?php echo $b_id; ?>">
						<img class="img-rounded" src="<?php echo $bImage; ?>" height="210" width="250">
	  		 		</a>
 					
						<div id="myModal<?php echo $b_id; ?>" class="modal fade" role="dialog">
						  <div class="modal-dialog">

						  
						    <div class="modal-content">
						      <div class="modal-header">
						        <button type="button" class="close" data-dismiss="modal">&times;</button>
						      </div>
						      <div class="modal-body">
						      		<div class="row">
						      			<div class="col-md-6">
						      				<img src="<?php echo $bImage; ?>" height="250" width="250">
						      			</div>
						      			<div class="col-md-6">
						      				<form>
						      					<strong>Služba: </strong><?php echo $bName; ?><br />
							      				<strong>Popis: </strong><?php echo $bCap; ?><br />
							      				<strong>Cena: </strong><?php echo 'CZK '.number_format($bPrice, 2); ?><br />
							      				<strong>Email: </strong> <br />
							      				<input type = "text" id="dstntn<?php echo $b_id; ?>" >
							      				<br />
										   		<strong>Datum: </strong>&nbsp;
							      				<br /> 
										    	<input class="btn-default" id="rdate<?php echo $b_id; ?>" size="30" name="rdate" type="date" autocomplete="off">
										    	<br />
										    	<strong>Hodina: </strong>
										    	<br />
										    	<select class="btn-default" id="hr">
										    		<?php 
										    			$x = 12;
										    			for($time = 1; $time <= $x; $time++){
										    		?>
										    			<option value="<?php echo $time; ?>"><?php echo $time; ?></option>
										    		<?php
										    			}
										    		 ?>
										    	</select>
										    	<select class="btn-default" id="ampm">
										    		<option value="AM">AM</option>
										    		<option value="PM">PM</option>
										    	</select>
						      				</form>
					      				
						      			</div>
						      		</div>
						      </div>
						      <div class="modal-footer">
						        <button type="button" class="btn btn-default" data-dismiss="modal">
						        	Zavrit
						        </button>
						        <input type="submit" value="Rezervuj" onclick="bogkot('<?php echo $b_id; ?>')" class="btn btn-success" data-dismiss="modal">
						      </div>
						    </div>

						  </div>
						</div>

						
	  		 	<?php
		  		 		}
		  		 	}
		  		 ?>
		  </div>
		</div>

	</div>
<
	

 		<script src="../bootstrap/js/jquery-1.11.1.min.js"></script>
 		<script src="../bootstrap/js/dataTables.js"></script>
 		<script src="../bootstrap/js/dataTables2.js"></script>
 		<script src="../bootstrap/js/bootstrap.js"></script>

	</body>
</html>


<script type="text/javascript">

function bogkot(str){

	var dstntn = $('#dstntn'+str).val();

	var bid = str;
	var tid = '<?php echo $_SESSION['tourID']; ?>';
	var dstntn = $('#dstntn'+str).val();
	var rdate = $('#rdate'+str).val();
	var hr = $('#hr').val();
	var ampm = $('#ampm').val();


	var datas = "bid="+bid+"&tid="+tid+"&dstntn="+dstntn+"&rdate="+rdate+"&hr="+hr+"&ampm="+ampm;

	$.ajax({
		   type: "POST",
		   url: "reservedprocess.php",
		   data: datas
		}).done(function( data ) {
		  $('#info').html(data);
		});

}



</script>