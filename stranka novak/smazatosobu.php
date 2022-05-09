<!DOCTYPE html>
<html>
<head>
    <title>Smazani Osoby</title>
</head>
<body>
    <center>
        <h1>Smazat osobu</h1>
        
        <form action="" method="POST">
            <input type="text" name="id" placeholder="ID"/><br/>
            
            <input type="submit" name="smazat" value="Smazat Osobu"/>
        </form>
            <a href="obsluha.php"><button>Zpet</button></a>
    </center>
</body>
</html>

<?php
    $databaze = mysqli_connect('sql5.webzdarma.cz', 'mojepujcovna7822', 'L,cU1uZ6oA,4q#U^9_6g','mojepujcovna7822');
    $db = mysqli_select_db($databaze,'mojepujcovna7822');
    
    if(isset($_POST['smazat'])){
        $id = $_POST['ID'];
        
        $query = "DELETE FROM Osoba WHERE id='$id'";
        $query_run = mysqli_query($databaze,$query);
        
        if($query_run)
        {
            echo "Smazaní osoby proběhlo úspěšně";
        }
        else
        {
            echo "Smazání osoby proběhlo neúspěšně";
        }
    }
    
?>