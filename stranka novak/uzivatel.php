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
            <h2>Základní informace:</h2>
            <section>
                <article>
                    <h2>Vypujcene Veci:</h2>
                    <table>
                        <tr>
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
                            $nazev = mysqli_fetch_all(mysqli_query($databaze, "SELECT nazev FROM naradi WHERE id=" . htmlspecialchars($pujcka['naradi_ID'])), MYSQLI_ASSOC)[0]['nazev'];
                            echo "<td>" . $nazev . "</td>";
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
    <form action="http://mojepujcovna.borec.cz/obsluhaprihlaseni.php">
        <center><input type="submit" value="Obsluha" /></center>
    </form>
    </body>
</html>