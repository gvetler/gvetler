<?php
    session_start();
    // vypsání do databáze
    include "db.php";
    $field1 = $mysqli->real_escape_string(strip_tags($_POST['sluzby']));
    $field2 = $mysqli->real_escape_string(strip_tags($_POST['jmeno']));
    $field3 = $mysqli->real_escape_string(strip_tags($_POST['email']));
    $field4 = $mysqli->real_escape_string(strip_tags($_POST['datum']));
     
    $query = "INSERT INTO objednavky (typ_sluzby, jmeno, email, datum) VALUES ('{$field1}','{$field2}','{$field3}','{$field4}')";
    

    
    if (!$mysqli->query($query)) {
        $_SESSION['chyba'] = "Daná služba už je v daný den rezervovaná";
    }
    $mysqli->close();

    $predmet = "Rezervace služby";
    $zprava = "Dobrý den, " . $_POST['jmeno'] . ", rezervoval/a jste si " . $_POST['sluzby'] . " na datum " . $_POST['datum'] . ".";

    $mejl = mail($_POST['jmeno'] . "<" . $_POST['email'] . ">", $predmet, $zprava, "From: GucciGangSluzby@gmail.com");

    header("location: index.php");0
?>



























































































































