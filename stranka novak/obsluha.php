<!DOCTYPE html>
<html lang="cs-cz">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>Knihovna</title>
        <link rel="stylesheet" href="style.css">
    </head>
    <body>
    <?php

    $databaze = mysqli_connect('sql5.webzdarma.cz', 'mojepujcovna7822', 'L,cU1uZ6oA,4q#U^9_6g','mojepujcovna7822');


   ?>
       
    

        <div class="cast">
            <br>
            <h1>Základní informace:</h1>
            <section>
                <article>
                    <h2>Osoby:</h2>
                    <div>
                        <form action="zmenaosoby.php">
                            <center><input type="submit" value="Zmena" /></center>
                        </form>
                        <form action="pridatosobu.php">
                            <center><input type="submit" value="Pridat" /></center>
                        </form>
                        <form action="smazatosobu.php">
                            <center><input type="submit" value="Smazat" /></center>
                        </form>
                    </div>
                        <table>
                            <tr>
                                <th>ID</th>
                                <th>Jmeno</th>
                                <th>Prijmeni</th>
                                <th>Adresa</th>
                                <th>Email</th>
                                <th>Telefon</th>
                            </tr>
                        <?php
                            $seznamOsob = mysqli_fetch_all(mysqli_query($databaze, "SELECT * FROM pujcujici ORDER BY id"), MYSQLI_ASSOC);
                            foreach ($seznamOsob as $osoba)
                            {
                                echo "<tr>";
                                echo "<td>" . htmlspecialchars($osoba['ID']) . "</td>";
                                echo "<td>" . htmlspecialchars($osoba['Jmeno']) . "</td>";
                                echo "<td>" . htmlspecialchars($osoba['Prijmeni']) . "</td>";
                                echo "<td>" . htmlspecialchars($osoba['Adresa']) . "</td>";
                                echo "<td>" . htmlspecialchars($osoba['Email']) . "</td>";
                                echo "<td>" . htmlspecialchars($osoba['Telefon']) . "</td>";
                                echo "</tr>";
                            }
                        ?>
                        </table>
                </article>

                <article>
                    <h2>Veci:</h2>
                    <div>
                        <form action="zmenaosoby.php">
                            <center><input type="submit" value="Zmena" /></center>
                        </form>
                        <form action="pridatosobu.php">
                            <center><input type="submit" value="Pridat" /></center>
                        </form>
                        <form action="smazatosobu.php">
                            <center><input type="submit" value="Smazat" /></center>
                        </form>
                    </div>
                    <table>
                        <tr>
                            <th>ID</th>
                            <th>Nazev</th>
                            <th>Vlastnost</th>
                        </tr>
                        <?php
                        $seznamVeci = mysqli_fetch_all(mysqli_query($databaze, "SELECT * FROM naradi ORDER BY id"), MYSQLI_ASSOC);
                        foreach ($seznamVeci as $vec)
                        {
                            echo "<tr>";
                            echo "<td>" . htmlspecialchars($vec['ID']) . "</td>";
                            echo "<td>" . htmlspecialchars($vec['Nazev']) . "</td>";
                            echo "<td>" . htmlspecialchars($vec['Vlastnosti']) . "</td>";
                            echo "</tr>";
                        }
                        ?>
                    </table>
                </article>
                
                <article>
                    <h2>Vypujcene Veci:</h2>
                    <table>
                        <tr>
                            <th>Osoba</th>
                            <th>Vec</th>
                            <th>Datum Od</th>
                            <th>Datum Do
                            <th>K dispozici</th>
                        </tr>
                        <?php
                        $vypujceneVeci = mysqli_fetch_all(mysqli_query($databaze, "SELECT * FROM naradipujcujici ORDER BY Datum_Od"), MYSQLI_ASSOC);
                        foreach ($vypujceneVeci as $pujcka)
                        {
                            
                            echo "<tr>";
                            echo "<td>" . htmlspecialchars($pujcka['naradi_ID']) . "</td>";
                            echo "<td>" . htmlspecialchars($pujcka['pujcujici_ID']) . "</td>";
                            echo "<td>" . htmlspecialchars($pujcka['Datum_Od']) . "</td>";
                            echo "<td>" . htmlspecialchars($pujcka['Datum_Do']) . "</td>";
                            echo "<td>" . htmlspecialchars($pujcka['K_Dispozici']) . "</td>";
                            echo "</tr>";
                        }
                        ?>
                    </table>
                </article>
                </section>
        </div>
        <div>
            <form action="email.php">
                            <center><input type="submit" value="Odeslani Emailu" /></center>
                            <a>
            <center><a href="graf.php"></a></center>
                Graf
           
           
        </div>
    </body>
</html>