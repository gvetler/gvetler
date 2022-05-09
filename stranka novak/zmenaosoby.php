<!DOCTYPE html>
<html>
<head>
    <title>Zmena dat osoby</title>
</head>
<body>
    <center>
        <h1>Zmena dat osoby</h1>
        
        <form action="" method="POST">
            <input type="text" name="id" placeholder="ID"/><br/>
            <input type="text" name="Jmeno" placeholder="Jmeno"/><br/>
            <input type="text" name="Prijmeni" placeholder="Prijmeni"/><br/>
            <input type="text" name="Adresa" placeholder="Adresa"/><br/>
            <input type="text" name="Email" placeholder="Email"/><br/>
            <input type="text" name="Telefon" placeholder="Telefon"/><br/>
            
            <input type="submit" name="aktualizovat" value="AKTUALIZOVAT_DATA"/>
        </form>
            <a href="obsluha.php"><button>Zpet</button></a>
    </center>
</body>
</html>

<?php
    $databaze = mysqli_connect('sql5.webzdarma.cz', 'knihovnakval4684', 'Ye.V1I(MHsM^sg8^424c','knihovnakval4684');
    $db = mysqli_select_db($databaze,'knihovnakval4684');
    
    if(isset($_POST['aktualizovat'])){
        $id = $_POST['id'];
        $Jmeno = $_POST['Jmeno'];
        $Prijmeni = $_POST['Prijmeni'];
        $Adresa = $_POST['Adresa'];
        $Email = $_POST['Email'];
        $Telefon = $_POST['Telefon'];
        
        $query = "UPDATE Osoba SET Jmeno='$Jmeno' , Prijmeni='$Prijmeni', Adresa ='$Adresa',Email ='$Email',Telefon ='$Telefon' WHERE ID ='$id'"; 
        $query_run = mysqli_query($databaze,$query);
        
        if($query_run){
            echo "Aktualizace dat proběhla úspěšně";
        }
        else{
            echo"Aktualizace dat proběhla neúspěšně";
        }
    }
    
?>