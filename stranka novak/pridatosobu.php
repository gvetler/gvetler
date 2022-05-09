<!DOCTYPE html>
<html>
<head>
    <title>Pridani Osoby</title>
</head>
<body>
    <center>
        <h1>Pridat osobu</h1>
        
        <form action="" method="POST">
            <input type="text" name="Jmeno" placeholder="Jmeno"/><br/>
            <input type="text" name="Prijmeni" placeholder="Prijmeni"/><br/>
            <input type="text" name="Adresa" placeholder="Adresa"/><br/>
            <input type="text" name="Email" placeholder="Email"/><br/>
            <input type="text" name="Telefon" placeholder="Telefon"/><br/>
            
            <input type="submit" name="pridat" value="Pridat Osobu"/>
        </form>
            <a href="obsluha.php"><button>Zpet</button></a>
    </center>
</body>
</html>

<?php
    $databaze = mysqli_connect('sql5.webzdarma.cz', 'mojepujcovna7822', 'L,cU1uZ6oA,4q#U^9_6g','mojepujcovna7822');
    $db = mysqli_select_db($databaze,'mojepujcovna7822');
    
    if(isset($_POST['pridat'])){
        $ID = $_POST['ID'];
        $Jmeno = $_POST['Jmeno'];
        $Prijmeni = $_POST['Prijmeni'];
        $Adresa = $_POST['Adresa'];
        $Email = $_POST['Email'];
        $Telefon = $_POST['Telefon'];
        
        $query = "INSERT INTO Osoba (ID, Jmeno, Prijmeni, Adresa, Email, Telefon) VALUES (NULL,' $Jmeno ',' $Prijmeni ',' $Adresa ',' $Email ',' $Telefon ')";
        $query_run = mysqli_query($databaze,$query);
        
        if($query_run)
        {
            echo "Přídaní osoby proběhlo úspěšně";
        }
        else
        {
            echo "Přidaní osoby proběhlo neúspěšně";
        }
    }
    
?>