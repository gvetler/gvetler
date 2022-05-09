<?php		
	if(isset($_POST['posli'])){
		
			$predmet = $_POST['predmet'];
			$mailfrom = $_POST['mail'];
			$zprava = $_POST['zprava'];
			$mailto = "pujcovnaaut37@gmail.com";
			$hl = "From:".$mailfrom;
			$predmet2 = "Potvrzeni";
			$zprava2 = "Zprava byla odeslana";
			$hl2 = "From:".$mailto;
			mail($mailfrom, $predmet2, $zprava2, $hl2);
			mail($mailto, $predmet, $zprava, $hl);
			
			header("Location: index.php?odeslano");	
			}
	

	