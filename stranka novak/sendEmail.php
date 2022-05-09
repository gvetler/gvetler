<?php
    $jmeno = $_POST['jmeno'];
    $email = $_POST['email'];
    $predmet = $_POST['predmet'];
    $zprava = $_POST['zprava'];
    
    $hlavicka = "From: <".$email.">\r\n";
    
    $vysledek = "";
    if(mail("patera@spscv.cz", $predmet,$zprava, $hlavicka)) {
        $vysledek = "Email byl odeslán.";
    }
    else {
        $vysledek = "Email nebyl odeslán.";
    }
?>

<!DOCTYPE html>
<html lang="cs-cz">
<head>
</head>
<body>
    <h4>
        <?php
        echo $vysledek;
        ?>
    </h4>
</body>
