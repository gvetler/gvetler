<?php 
	include_once('config.php');
	$db = new Database();

	if(isset($_POST['login']))
	{
		$un = $_POST['un'];
		$up = $_POST['up'];

		$up = md5($up);

		$sql = 'SELECT * FROM uzivatele WHERE u_pr = ? AND u_up = ?';
		$result = $db->getRow($sql, [$un, $up]);
		

		if($result){
			$r = $result['user_type'];

			if($r == '1'){
				$_SESSION['logged'] = '1';
				
			}else{
				$_SESSION['logged'] = '2';

				$_SESSION['tourID'] = $result['u_id'];

				header('location: uzivatele/index.php');
			}
		}

	}
 ?>

<!DOCTYPE html>
<html lang="">
	<head>
		<meta charset="utf-8">
		<meta http-equiv="X-UA-Compatible" content="IE=edge">
		<meta name="viewport" content="width=device-width, initial-scale=1">
		<titleRezervace sluzeb</title>

		
		<link rel="stylesheet" type="text/css" href="bootstrap/css/bootstrap.css">
		<link rel="stylesheet" type="text/css" href="bootstrap/css/jquery.dataTables.css">

	</head>

	<style type="text/css">
		.navbar { margin-bottom:0px !important; }
		.carousel-caption { margin-top:0px !important }
	</style>



	<body>
<br />
<br />
<br />
<br />
<br />
<br />
		<div class="row">
			<div class="col-md-4"></div>
			<div class="col-md-4">
				<div class="panel panel-info">
					<div class="panel-heading">
						<h3 class="panel-title">Prihlasit se</h3>
					</div>
					<div class="panel-body">
						 <form action="" method="post">
							 	<div class="form-group">
							    <label for="inputdefault">Prihlasovaci jmeno:</label>
							    <input class="form-control" name="un" type="text" required autofocus
							    value="<?php if(isset($_POST['un'])){echo $_POST['un'];} ?>"
							    >
							  </div>

							   <div class="form-group">
							    <label for="inputdefault">Heslo:</label>
							    <input class="form-control" name="up" type="password" required>
							  </div>

							  <button class="btn btn-info" type="submit" name="login">
							  	Prihlas se
							  	
							  </button>
						 </form>
					</div>
				</div>
			</div>
			<div class="col-md-4"></div>
		</div>
		
		

 		<script src="bootstrap/js/jquery-1.11.1.min.js"></script>
 		<script src="bootstrap/js/dataTables.js"></script>
 		<script src="bootstrap/js/dataTables2.js"></script>
 		<script src="bootstrap/js/bootstrap.js"></script>

	</body>
</html>