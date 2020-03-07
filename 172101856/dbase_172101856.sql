/*
Navicat MySQL Data Transfer

Source Server         : risa feby rastuti
Source Server Version : 50624
Source Host           : localhost:3306
Source Database       : dbase_172101856

Target Server Type    : MYSQL
Target Server Version : 50624
File Encoding         : 65001

Date: 2018-11-13 15:32:37
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `tb_anggota`
-- ----------------------------
DROP TABLE IF EXISTS `tb_anggota`;
CREATE TABLE `tb_anggota` (
  `kodeanggota` varchar(9) NOT NULL DEFAULT '',
  `namaanggota` varchar(30) DEFAULT NULL,
  `alamat` varchar(30) DEFAULT NULL,
  `kontak` varchar(15) DEFAULT NULL,
  `email` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`kodeanggota`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tb_anggota
-- ----------------------------

-- ----------------------------
-- Table structure for `tb_buku`
-- ----------------------------
DROP TABLE IF EXISTS `tb_buku`;
CREATE TABLE `tb_buku` (
  `kodebuku` varchar(9) NOT NULL DEFAULT '',
  `judulbuku` varchar(30) DEFAULT NULL,
  `kodepenulis` varchar(9) NOT NULL DEFAULT '',
  `kodepenerbit` varchar(9) NOT NULL DEFAULT '',
  `tahunpenerbit` varchar(4) DEFAULT NULL,
  `jumlahhalaman` varchar(4) DEFAULT NULL,
  PRIMARY KEY (`kodebuku`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tb_buku
-- ----------------------------

-- ----------------------------
-- Table structure for `tb_penerbit`
-- ----------------------------
DROP TABLE IF EXISTS `tb_penerbit`;
CREATE TABLE `tb_penerbit` (
  `kodepenerbit` varchar(9) NOT NULL DEFAULT '',
  `namapenerbit` varchar(30) DEFAULT NULL,
  `alamatpenerbit` varchar(30) DEFAULT NULL,
  `kontak` varchar(15) DEFAULT NULL,
  `emailpenerbit` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`kodepenerbit`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tb_penerbit
-- ----------------------------

-- ----------------------------
-- Table structure for `tb_penulis`
-- ----------------------------
DROP TABLE IF EXISTS `tb_penulis`;
CREATE TABLE `tb_penulis` (
  `kodepenulis` varchar(9) NOT NULL DEFAULT '',
  `namapenulis` varchar(30) DEFAULT NULL,
  `alamatpenulis` varchar(30) DEFAULT NULL,
  `kontak` varchar(15) DEFAULT NULL,
  `emailpenulis` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`kodepenulis`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tb_penulis
-- ----------------------------

-- ----------------------------
-- View structure for `view_anggota`
-- ----------------------------
DROP VIEW IF EXISTS `view_anggota`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `view_anggota` AS select `tb_anggota`.`kodeanggota` AS `Kode Anggota`,`tb_anggota`.`namaanggota` AS `Nama Anggota`,`tb_anggota`.`alamat` AS `Alamat Anggota`,`tb_anggota`.`kontak` AS `Kontak Anggota`,`tb_anggota`.`email` AS `Email Anggota` from `tb_anggota`;

-- ----------------------------
-- View structure for `view_buku`
-- ----------------------------
DROP VIEW IF EXISTS `view_buku`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `view_buku` AS select `tb_buku`.`kodebuku` AS `Kode Buku`,`tb_buku`.`judulbuku` AS `Judul Buku`,`tb_buku`.`tahunpenerbit` AS `Tahun Penerbit`,`tb_buku`.`jumlahhalaman` AS `Jumlah Halaman`,`tb_penerbit`.`namapenerbit` AS `Nama Penerbit`,`tb_penulis`.`namapenulis` AS `Nama Penulis` from ((`tb_buku` join `tb_penerbit` on(((`tb_penerbit`.`kodepenerbit` = `tb_buku`.`kodepenerbit`) and (`tb_buku`.`kodepenerbit` = `tb_buku`.`kodepenulis`)))) join `tb_penulis` on(((`tb_penulis`.`kodepenulis` = `tb_buku`.`kodepenulis`) and (`tb_penulis`.`kodepenulis` = `tb_buku`.`kodepenulis`))));

-- ----------------------------
-- View structure for `view_penerbit`
-- ----------------------------
DROP VIEW IF EXISTS `view_penerbit`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `view_penerbit` AS select `tb_penerbit`.`kodepenerbit` AS `Kode Penerbit`,`tb_penerbit`.`namapenerbit` AS `Nama Penerbit`,`tb_penerbit`.`alamatpenerbit` AS `Alamat Penerbit`,`tb_penerbit`.`kontak` AS `Kontak Penerbit`,`tb_penerbit`.`emailpenerbit` AS `Email Penerbit` from `tb_penerbit`;

-- ----------------------------
-- View structure for `view_penulis`
-- ----------------------------
DROP VIEW IF EXISTS `view_penulis`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `view_penulis` AS select `tb_penulis`.`kodepenulis` AS `Kode Penulis`,`tb_penulis`.`namapenulis` AS `Nama Penulis`,`tb_penulis`.`alamatpenulis` AS `Alamat Penulis`,`tb_penulis`.`kontak` AS `Kontak Penulis`,`tb_penulis`.`emailpenulis` AS `Email Penulis` from `tb_penulis`;
