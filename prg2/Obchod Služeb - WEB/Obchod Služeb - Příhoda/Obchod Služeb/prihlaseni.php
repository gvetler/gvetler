<?php
	session_start();
	include "db.php";

	$meno = "majitel";
	$heslo = "Majiteljefrajer69";

    // kontrola zadanych udaju
	if ($_POST['jmeno'] != $meno || $_POST['heslo'] != $heslo) {
		$_SESSION['chyba'] = "Neplatné majitelské jméno nebo heslo";
		header("location: index.php");
	}

    // tabulka a vypis z databaze
	echo "<table border=\"1px\">";
	echo "<tr><th>ID</th><th>Služba</th><th>Jméno zákazníka</th><th>E-mail</th><th>Datum</th></tr>";
	$dotaz = "SELECT * FROM objednavky";
	$query = $mysqli->query($dotaz);
	while ($a = mysqli_fetch_assoc($query)) {
		echo "<tr>";
			echo "<td>";
				echo $a['id'];
			echo "</td>";
			echo "<td>";
				echo $a['typ_sluzby'];
			echo "</td>";
			echo "<td>";
				echo $a['jmeno'];
			echo "</td>";
			echo "<td>";
				echo $a['email'];
			echo "</td>";
			echo "<td>";
				echo $a['datum'];
			echo "</td>";
		echo "</tr>";
	}
	echo "</table>";
?>