
create Database `persoane`;
use `persoane`;
CREATE TABLE IF NOT EXISTS `persoane` (
    `id` int(11) NOT NULL AUTO_INCREMENT,
    `nume` varchar(40) NOT NULL,
    `functia` varchar(20) NOT NULL,
    `institutia` varchar(25)NOT NULL,
    PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=253 DEFAULT CHARSET=utf8;



INSERT INTO `persoane` ( `id` , `nume` , `functia` , `institutia` ) VALUES
(1,"Gidea Vladut Madalin","Student","Universitatii Spiru Haret"),
(2,"Mihailescu Marius Iulian","Profesor","Universitatii Spiru Haret");