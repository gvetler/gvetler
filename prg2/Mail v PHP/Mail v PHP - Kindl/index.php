<!DOCTYPE html>
<html lang="">
	<head>
		<meta charset="utf-8">		
		<title>Email Formulář</title>

		<link rel="stylesheet"  href="style.css">				
	</head>
	<body>
		<main>
		<p>Email Formulář</p>
		<form class ="contact-form" action = "mail.php" method = "post">
		<center><input type="text" name = "mail" placeholder = "Email Váš" ></center>
		<center><input type="text" name = "predmet" placeholder = "Předmět" ></center>
		<center><textarea name = "zprava" placeholder = "Zpráva"></textarea></center>
		<center><button type = "submit" name = "posli">Posli email</button>	</center>	
		</main>
			
	</body>
		
</html>


