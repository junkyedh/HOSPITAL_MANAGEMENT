-- Create table PATIENT
CREATE TABLE "PATIENT" (
    PATIENTID SERIAL PRIMARY KEY,
    FIRSTNAME VARCHAR(100),
    LASTNAME VARCHAR(100),
    BIRTHDAY DATE,
    GENDER INT,
    ICN NUMERIC(9, 0),
    PROFESSION VARCHAR(100),
    ADDRESS VARCHAR(100),
    DEPOSIT MONEY,
    STATE INT
);
ALTER TABLE "PATIENT"
ADD CONSTRAINT PATIENT_id_range_check CHECK (PATIENTID >= 10000000 AND PATIENTID <= 99999999);

--Thêm dữ liệu cho bảng "PATIENT"
INSERT INTO "PATIENT" (PATIENTID, FIRSTNAME, LASTNAME, BIRTHDAY, GENDER, ICN, PROFESSION, ADDRESS, DEPOSIT, STATE) 
VALUES 
	(10000000, 'Đăng', 'Nguyễn Như Hải','1975-01-01', 0, 123456789, 'Sinh viên', 'KTX ĐH QG', 0.0000, 1),
	(10000001, 'Ân', 'Nguyễn Hồng','1974-12-31', 0, 123456789, 'Sinh viên', 'KTX ĐHQG', 0.0000, 1),
	(10000002, 'Lê', 'Bá Nam','1980-12-31', 0, 273410135, 'Sinh viên', 'KTX DHQG', 0.0000, 1),
	(10000003, 'Luân', 'Phan Ngọc Minh','1982-12-31', 0, 273410136, 'Sinh viên', 'KTX DHQG', 0.0000, 1),
	(10000004, 'Sỹ', 'Nguyễn Duy', '1982-12-31', 0, 273410137, 'Sinh viên', 'KTX DHQG', 0.0000, 1),
	(10000005, 'Hiền', 'Nguyễn Bạch', '1996-01-01', 1, 273410138, 'Sinh viên', 'KTX DHQG', 0.0000, 1),
	(10000006, 'Hiệp', 'Lê Nguyễn Hào','1972-01-01', 0, 273410138, 'Sinh viên', 'KTX DHQG', 0.0000, 0),
	(10000007, 'Nhung', 'Võ Thị Bích', '1972-01-01', 1, 273410139, 'Sinh viên', 'KTX DHQG', 0.0000, 0),
	(10000008, 'Thi', 'Lê Thị Thu', '1971-12-31', 1, 273410139, 'Sinh viên', 'KTX ĐHQG', 0.0000, 0),
	(10000009, 'Xuyến', 'Lê Thị', '1997-05-01', 1, 273410140, 'Sinh viên', 'KTX DHQG', 0.0000, 0),
	(10000010, 'Thương', 'Nguyễn Thị', '1996-07-03', 1, 273410141, 'Sinh viên', 'KTX DHQG', 0.0000, 0),
	(10000011, 'Khanh', 'Nguyễn Việt Mai', '1996-04-23', 1, 273410142, 'Sinh viên', 'KTX DHQG', 0.0000, 0),
	(10000012, 'Cường', 'Dương Nguyễn Khánh', '1995-08-22', 0, 273410143, 'Sinh viên', 'KTX DHQG', 0.0000, 0),
	(10000013, 'Lâm', 'Phạm Văn', '1995-09-30', 0, 273410144, 'SInh viên', 'KTX DHQG', 0.0000, 0),
	(10000014, 'Huy', 'Bùi Ngọc', '1995-09-18', 0, 273410145, 'Sinh viên', 'KTX DHQG', 0.0000, 0),
	(10000015, 'Quốc', 'Nguyễn Việt', '1995-10-04', 0, 273410146, 'Sinh viên', 'KTX DHQG', 0.0000, 0),
	(10000016, 'Tân', 'Nguyễn Minh', '1996-06-03', 0, 273410147, 'Sinh viên', 'KTX DHQG', 0.0000, 0),
	(10000017, 'Hiếu', 'Nguyễn Hoàng', '1993-05-22', 0, 273410148, 'Sinh viên', 'KTX DHQG', 0.0000, 0),
	(10000029, 'Duy', 'Chung Ngọc Minh', '2004-09-14', 0, 273410161, 'Sinh viên', 'KTX ĐH QG', 0.0000, 0),
	(10000030, 'Duy', 'Phạm Thế', '2001-10-28', 0, 273410162, 'Sinh viên', 'KTX ĐH QG', 0.0000, 0),
	(10000031, 'Duy', 'Đoàn', '2003-02-24', 0, 273410163, 'Sinh viên', 'KTX ĐH QG', 0.0000, 0),
	(10000032, 'Duy', 'Nguyễn Hồng', '2005-07-07', 0, 273410164, 'Sinh viên', 'KTX ĐH QG', 0.0000, 0),
	(10000033, 'Đại', 'Nguyễn Ngọc', '2004-11-15', 0, 273410165, 'Sinh viên', 'KTX ĐH QG', 0.0000, 0),
	(10000034, 'Đắc', 'Vũ Trọng', '2002-05-24', 0, 273410166, 'Sinh viên', 'KTX ĐH QG', 0.0000, 0),
	(10000035, 'Đôn', 'Nguyễn Phượng', '2006-01-09', 0, 273410167, 'Sinh viên', 'KTX ĐHQG', 0.0000, 0),
	(10000036, 'Đông', 'Lê Phước', '2005-07-21', 0, 273410168, 'Sinh viên', 'KTX ĐHQG', 0.0000, 0),
	(10000037, 'Đức', 'Nguyễn Chí Duy', '2002-07-03', 0, 273410168, 'Sinh viên', 'KTX ĐHQG', 0.0000, 0),
	(10000038, 'Hoàn', 'Ngô Đình Thế', '2002-08-13', 0, 273410170, 'Sinh viên', 'KTX ĐHQG', 0.0000, 0),
	(10000039, 'Huy', 'Phan Hữu', '2005-10-21', 0, 273410171, 'Sinh viên', 'KTX ĐHQG', 0.0000, 0),
	(10000040, 'Huy', 'Ngô Việt Khánh', '2001-10-29', 0, 273410172, 'Sinh viên', 'KTX ĐHQG', 0.0000, 0),
	(10000046, 'Khoa', 'Phạm Anh', '2005-08-24', 0, 273410178, 'Sinh viên', 'KTX ĐHQG', 0.0000, 0),
	(10000047, 'Khoa', 'Cù Duy', '2004-01-18', 0, 273410179, 'Sinh viên', 'KTX ĐHQG', 0.0000, 0),
	(10000048, 'Kiên', 'Nguyễn Trung', '2000-05-23', 0, 273410180, 'Sinh viên', 'KTX ĐHQG', 0.0000, 0),
	(10000049, 'Lãm', 'Lê Quang', '2003-07-09', 0, 273410181, 'Sinh viên', 'KTX ĐHQG', 0.0000, 0),
	(10000050, 'Lâm', 'Phạm Phú', '2000-08-15', 0, 273410182, 'Sinh viên', 'KTX ĐHQG', 0.0000, 0),
	(10000051, 'Linh', 'Nguyễn Thế Quang', '2001-05-02', 0, 273410184, 'Sinh viên', 'KTX ĐHQG', 0.0000, 0),
	(10000052, 'Long', 'Phan Bá', '2002-02-02', 0, 273410185, 'Sinh viên', 'KTX ĐHQG', 0.0000, 0),
	(10000053, 'Luân', 'Trần Hoàng', '2003-07-31', 0, 273410186, 'Sinh viên', 'KTX ĐHQG', 0.0000, 0),
	(10000054, 'Minh', 'Văn Ngọc', '2004-02-10', 0, 273410187, 'Sinh viên', 'KTX ĐHQG', 0.0000, 0),
	(10000055, 'Nghĩa', 'Phạm Trọng', '2006-10-30', 0, 273410188, 'Sinh viên', 'KTX ĐHQG', 0.0000, 0),
	(10000056, 'Nguyên', 'Bùi Thành', '2007-01-14', 0, 273410189, 'Sinh viên', 'KTX ĐHQG', 0.0000, 0),
	(10000057, 'Nguyên ', 'Phạm Trung', '2022-01-25', 0, 273410190, 'Sinh viên', 'KTX ĐHQG', 0.0000, 0),
	(10000058, 'Nhân', 'Nguyễn Thành', '2003-06-17', 0, 273410191, 'Sinh viên', 'KTX ĐHQG', 0.0000, 0)

-- Create table MEDICINE
CREATE TABLE "MEDICINE" (
    MEDICINEID SERIAL PRIMARY KEY,
    MEDICINENAME VARCHAR(100),
    QUANTITY INT,
    PRICE MONEY
);
ALTER TABLE "MEDICINE"
ADD CONSTRAINT medicine_id_range_check CHECK (MEDICINEID >= 100000 AND MEDICINEID <= 999999);

--Thêm dữ liệu cho bảng "MEDICINE"
INSERT INTO "MEDICINE" (MEDICINEID, MEDICINENAME, QUANTITY, PRICE) 
VALUES 
	(100001, 'BAR', 1000, 13000.0000),
	(100002, 'Bidioslama', 1000, 123000.0000),
	(100003, 'Bổ thận dương', 1000, 40000.0000),
	(100004, 'Clesamphenicol', 1000, 2000.0000),
	(100005, 'Cốm trẻ em', 1000, 6000.0000),
	(100006, 'Cù là con ó', 1000, 20000.0000),
	(100007, 'Dạ hương', 1000, 12000.0000),
	(100008, 'Dầu khinh diệp', 1000, 12000.0000),
	(100009, 'Evasol 250 ml', 1000, 66000.0000),
	(100010, 'Evasol 500 ml', 1000, 99000.0000),
	(100011, 'Gennamecin', 1000, 2000.0000),
	(100012, 'Glucose', 1000, 10000.0000),
	(100013, 'Gyno opc', 1000, 5000.0000),
	(100014, 'Gynofar', 1000, 7000.0000),
	(100015, 'Mollium 30ml', 1000, 20000.0000),
	(100016, 'Natri Bicarbonal', 1000, 38000.0000),
	(100017, 'Orafa', 1000, 4000.0000),
	(100018, 'Oxy già', 1000, 1000.0000),
	(100019, 'Panthenol', 1000, 102000.0000),
	(100020, 'Pectol 90ml', 1000, 10500.0000),
	(100021, 'Phytogymo', 1000, 15000.0000),
	(100022, 'Viên sỏi thận', 1000, 50000.0000),
	(100023, 'Aremuc 100mg', 1000, 1400.0000),
	(100024, 'Aremuc 200mg', 1000, 2000.0000);

-- Create table MATERIAL
CREATE TABLE "MATERIAL" (
    MATERIALID SERIAL PRIMARY KEY,
    MATERIALNAME VARCHAR(100),
    QUANTITY INT,
    PRICE MONEY
);
ALTER TABLE "MATERIAL"
ADD CONSTRAINT MATERIAL_id_range_check CHECK (MATERIALID >= 100 AND MATERIALID <= 999);

--Thêm dữ liệu cho bảng "MATERIAL"
INSERT INTO "MATERIAL" (MATERIALID, MATERIALNAME, QUANTITY, PRICE) 
VALUES 
  (101, 'Chăn', 15, 15000.0000),
  (102, 'Mùng', 1000, 10000.0000),
  (104, 'Gối', 200, 20000.0000),
  (105, 'Gối ngắn', 200, 15000.0000),
  (106, 'Gối dài', 200, 10000.0000),
  (107, 'Ghế dài', 11, 10000.0000),
  (108, 'Ghế nhựa', 100, 11111.0000);

-- Create table MAJOR
CREATE TABLE "MAJOR" (
    MAJORID SERIAL PRIMARY KEY,
    MATERIALNAME VARCHAR(100),
    MAJORNAME varchar(100) NULL
);
ALTER TABLE "MAJOR"
ADD CONSTRAINT MAJOR_id_range_check CHECK (MAJORID >= 100 AND MAJORID <= 999);

--Thêm dữ liệu cho bảng "MAJOR"
INSERT INTO "MAJOR" (MAJORID, MAJORNAME)
VALUES 
	(100, 'Răng hàm mặt'),
	(101, 'Điều dưỡng'),
	(102, 'Y tá'),
	(103, 'Đa khoa'),
	(104, 'Tai mũi'),
	(106, 'Giải phẩu học');

-- Create table DEPARTMENT
CREATE TABLE "DEPARTMENT" (
    DEPARTMENTID SERIAL PRIMARY KEY,
    DEPARTMENTNAME VARCHAR(100)
);
ALTER TABLE "DEPARTMENT"
ADD CONSTRAINT DEPARTMENT_id_range_check CHECK (DEPARTMENTID >= 100 AND DEPARTMENTID <= 999);

--Thêm dữ liệu cho bảng "DEPARTMENT"
INSERT INTO "DEPARTMENT" (DEPARTMENTID, DEPARTMENTNAME)
VALUES 
    (100, 'Khoa phẩu thuật'),
    (102, 'Khoa nội'),
    (104, 'Khoa ngoại'),
    (105, 'Khoa sản'),
    (106, 'Khoan kiểm soát nhiểm khuẩn'),
    (107, 'Khoa dược'),
    (108, 'Khoa chuẩn đoán hình ảnh'),
    (109, 'Tổ dinh dưỡng tiết chế'),
    (110, 'Phòng chiến lược phát triển'),
    (111, 'Phòng IT'),
    (112, 'Phòng kế hoạch tổng hợp'),
    (113, 'Phòng vật tư thiết bị y tế');

--Tạo bảng "BILL"
CREATE TABLE "BILL" (
    BILLID SERIAL PRIMARY KEY,
    BILLTYPEID numeric(3,0),
    PATIENTID numeric(8,0),
    STAFFID numeric(8,0),
    DATE timestamp,
    TOTALPRICE money,
    STATE integer
);

----Đổi kiểu dữ liệu id sang integer
ALTER TABLE "BILL"
	ALTER COLUMN BILLTYPEID TYPE integer USING BILLTYPEID::integer,
	ALTER COLUMN PATIENTID TYPE integer USING PATIENTID::integer,
	ALTER COLUMN STAFFID TYPE integer USING STAFFID::integer;
--Giới hạn dữ liệu cho id
ALTER TABLE "BILL"
	ADD CONSTRAINT BILLID_length_check CHECK (BILLID >= 10000000 AND BILLID <= 99999999),
	ADD CONSTRAINT BILLTYPEID_length_check CHECK (BILLTYPEID >= 100 AND BILLTYPEID <= 999),
	ADD CONSTRAINT PATIENTID_length_check CHECK (PATIENTID >= 10000000 AND PATIENTID <= 99999999),
	ADD CONSTRAINT STAFFID_length_check CHECK (STAFFID >= 10000000 AND STAFFID <= 99999999);

--Thêm dữ liệu vào bảng "BILL"
INSERT INTO "BILL" (BILLID, BILLTYPEID, PATIENTID, STAFFID, DATE, TOTALPRICE, STATE)
VALUES 
	(10000001, 101, 10000000, 10000000, '2023-06-05 02:27:47', 270000.0000, 1),
	(10000002, 102, 10000000, 10000000, '2023-06-05 05:21:43', 95000.0000, 1),
	(10000003, 101, 10000000, 10000000, '2023-06-05 05:22:00', 240000.0000, 1),
	(10000004, 102, 10000001, 10000000, '2023-06-05 05:22:00', 90000.0000, 0),
	(10000005, 102, 10000002, 10000000, '2023-06-05 05:22:21', 50000.0000, 0),
	(10000006, 101, 10000002, 10000000, '2023-06-05 05:22:21', 333000.0000, 0),
	(10000007, 102, 10000005, 10000000, '2023-06-05 05:22:36', 35000.0000, 0),
	(10000008, 102, 10000004, 10000000, '2023-06-05 05:22:36', 25000.0000, 0),
	(10000009, 101, 10000004, 10000000, '2023-06-05 05:22:36', 1450000.0000, 0),
	(10000010, 101, 10000004, 10000000, '2023-06-05 05:22:37', 320000.0000, 0),
	(10000011, 101, 10000005, 10000000, '2023-06-05 05:22:38', 5160000.0000, 0),
	(10000012, 101, 10000017, 10000000, '2023-06-05 05:22:44', 428000.0000, 0),
	(10000013, 101, 10000016, 10000000, '2023-06-05 05:22:45', 1000000.0000, 0),
	(10000014, 101, 10000015, 10000000, '2023-06-05 05:22:45', 180000.0000, 0),
	(10000015, 101, 10000014, 10000000, '2023-06-05 05:22:45', 45000.0000, 0),
	(10000016, 101, 10000013, 10000000, '2023-06-05 05:22:45', 1240000.0000, 0),
	(10000017, 101, 10000012, 10000000, '2023-06-05 05:22:46', 820000.0000, 0),
	(10000018, 101, 10000011, 10000000, '2023-06-05 05:22:46', 70030000.0000, 0),
	(10000019, 100, 10000000, 10000000, '2023-06-06 01:46:17', 95000.0000, 1),
	(10000020, 100, 10000000, 10000000, '2023-06-06 01:46:18', 241000.0000, 1),
	(10000021, 100, 10000000, 10000000, '2023-06-06 01:46:19', 95000.0000, 1);

-- Create table BILLTYPE
CREATE TABLE "BILLTYPE" (
    BILLTYPEID SERIAL PRIMARY KEY,
    TYPENAME VARCHAR(100) NULL
);
ALTER TABLE "BILLTYPE"
ADD CONSTRAINT BILLTYPE_id_range_check CHECK (BILLTYPEID >= 100 AND BILLTYPEID <= 999);

--Thêm dữ liệu cho bảng "BILLTYPE"
INSERT INTO "BILLTYPE" (BILLTYPEID, TYPENAME) 
VALUES 
    (100, 'Medicine'),
    (101, 'Service'),
    (102, 'Material');

-- Create table HOSPITALBED
CREATE TABLE "HOSPITALBED" (
    BEDID SERIAL PRIMARY KEY,
    PATIENT NUMERIC(8, 0),
    STATE INT
);
ALTER TABLE "HOSPITALBED"
ADD CONSTRAINT BED_id_range_check CHECK (BEDID >= 100 AND BEDID <= 999);

--Thêm dữ liệu cho bảng "HOSPITALBED"
INSERT INTO "HOSPITALBED" (BEDID, PATIENT, STATE) 
VALUES 
	(101, 10000000, 1), 
	(102, 10000002, 1), 
	(103, 0, 0), 
	(104, 0, 0), 
	(105, 0, 0), 
	(106, 0, 0), 
	(107, 0, 0), 
	(108, 0, 0), 
	(109, 0, 0), 
	(110, 0, 0), 
	(111, 0, 0), 
	(112, 0, 0), 
	(113, 0, 0), 
	(114, 0, 0), 
	(115, 0, 0), 
	(116, 0, 0), 
	(117, 0, 0), 
	(118, 0, 0), 
	(119, 0, 0), 
	(120, 0, 0), 
	(121, 0, 0), 
	(122, 0, 0), 
	(123, 0, 0), 
	(124, 0, 0), 
	(125, 0, 0), 
	(126, 0, 0), 
	(127, 0, 0), 
	(128, 0, 0), 
	(129, 0, 0), 
	(130, 0, 0);

-- Create table DISEASE
CREATE TABLE "DISEASE" (
    DISEASEID SERIAL PRIMARY KEY,
    DISEASENAME varchar(100) NULL,
    SYMPTOM varchar(1000) NULL
);
ALTER TABLE "DISEASE"
ADD CONSTRAINT DISEASE_range_check CHECK (DISEASEID >= 100 AND DISEASEID <= 999);

--Thêm dữ liệu cho bảng "HOSPITALBED"
INSERT INTO "DISEASE" (DISEASEID, DISEASENAME, SYMPTOM) VALUES 
	(110, 'Viêm mũi xoang cấp', 'ko'),
	(102, 'Tăng huyết áp', 'Ko'),
	(103, 'Suy tim', 'Ko'),
	(105, 'Huyết khối động - tim mạch ở chi', 'ko'),
	(106, ' Rối loạn nhịp không ảnh hưởng đến huyết động học: rung nhĩ, ngoại tâm Thu thất, nhịp chậm xoang', 'ko'),
	(107, 'Tăng áp động mạch phổi nhẹ - trung bình', 'ko'),
	(108, '- Viêm amidan hốc mủ', 'ko'),
	(109, 'Áp xe quanh amidan', 'ko'),
	(111, 'Viêm thanh quản cấp', 'ko'),
	(112, 'Viêm phế quản cấp', 'ko'),
	(113, 'Ho ra máu lượng ít - vừa', 'ko'),
	(114, 'Viêm phổi', 'ko'),
	(115, 'Viêm phổi thuỳ', 'ko'),
	(116, ' Áp xe phổi', 'ko'),
	(117, ' Tràn dịch màng phổi', 'ko'),
	(118, 'Tràn khí màng phổi', 'ko'),
	(119, 'Đợt cấp COPD', 'ko'),
	(120, 'Dãn phế quản bội nhiễm', 'ko'),
	(121, 'Hen phế quản', 'ko'),
	(122, 'Loét thực quản', 'ko'),
	(123, 'Viêm loét dạ dày – tá tràng cấp', 'ko'),
	(124, 'Xuất huyết tiêu hoá', 'ko'),
	(125, 'Hội chứng lỵ : trực tràng, amibe', 'ko'),
	(126, 'Viêm loét đại tràng - trực tràng', 'ko'),
	(127, 'IBS (hội chứng đại tràng kích thích)', 'ko'),
	(128, 'Viêm túi mật cấp không do sỏi', 'ko'),
	(129, 'Áp xe gan: vi trùng, amibe, sán lá gan', 'ko'),
	(130, 'Nhiễm trùng đường mật: sỏi OMC đã ERCP lấy sỏi, ngược dòng', 'ko'),
	(131, 'Xơ gan', 'ko'),
	(132, 'Viêm gan cấp', 'ko'),
	(133, 'Viêm tuỵ cấp', 'ko'),
	(134, 'Thương hàn', 'ko');

-- Create table ROLE
CREATE TABLE "ROLE" (
    ROLEID SERIAL PRIMARY KEY,
    ROLENAME VARCHAR(100) NOT NULL
);
ALTER TABLE "ROLE"
ADD CONSTRAINT ROLE_range_check CHECK (ROLEID >= 100 AND ROLEID <= 999);

--Thêm dữ liệu cho bảng "TESTTYPE"
INSERT INTO "ROLE" (ROLEID, ROLENAME) 
VALUES 
	(100, 'Quản lý nhân sự'),
	(102, 'Quản lý vật tư'),
	(103, 'Bác sĩ'),
	(105, 'Quản trị hệ thống');

--Tạo bảng "ROLEDETAIL"
CREATE TABLE "ROLEDETAIL" (
    ROLEID numeric(3, 0) NOT NULL,
    FUNCTIONID numeric(3, 0) NOT NULL,
    PRIMARY KEY (ROLEID, FUNCTIONID)
);

--Đổi kiểu dữ liệu id sang integer
ALTER TABLE "ROLEDETAIL"
	ALTER COLUMN ROLEID TYPE integer USING ROLEID::integer,
	ALTER COLUMN FUNCTIONID TYPE integer USING FUNCTIONID::integer;

--Giới hạn dữ liệu cho id
ALTER TABLE "ROLEDETAIL"
	ADD CONSTRAINT ROLEID_length_check CHECK (ROLEID >= 100 AND ROLEID <= 999),
	ADD CONSTRAINT FUNCTIONID_length_check CHECK (FUNCTIONID >= 100 AND FUNCTIONID <= 999);

--Thêm dữ liệu vào bảng "ROLEDETAIL"
INSERT INTO "ROLEDETAIL" (ROLEID, FUNCTIONID) 
VALUES 
	(105, 124),
	(105, 113),
	(105, 112),
	(105, 106),
	(105, 107),
	(105, 108),
	(105, 109),
	(105, 110),
	(105, 111),
	(105, 114),
	(105, 115),
	(105, 116),
	(105, 117),
	(105, 118),
	(105, 119),
	(105, 120),
	(105, 121),
	(105, 122),
	(105, 123),
	(105, 126),
	(100, 111),
	(100, 113),
	(100, 112),
	(102, 107),
	(102, 119),
	(102, 121),
	(103, 106),
	(103, 108),
	(103, 109),
	(103, 116),
	(103, 118),
	(103, 122),
	(103, 123),
	(103, 126),
	(100, 110);

--Tạo bảng "ROLEFUNCTION"
CREATE TABLE "ROLEFUNCTION" (
    FUNCTIONID SERIAL PRIMARY KEY,
    FUNCTIONNAME VARCHAR(100),
    BUTTON VARCHAR(50)
);
ALTER TABLE "ROLEFUNCTION"
	ADD CONSTRAINT ROLEFUNCTION_range_check CHECK (FUNCTIONID >= 100 AND FUNCTIONID <= 999);

--Thêm dữ liệu vào bảng "ROLEFUNCTION"
INSERT INTO "ROLEFUNCTION" (FUNCTIONID, FUNCTIONNAME, BUTTON) 
VALUES 
	(106, 'Quản lý bệnh nhân', 'tabItemPatient'),
	(107, 'Quản lý hóa đơn', 'tabItemBill'),
	(108, 'Quản lý phiếu khám bệnh', 'tabItemExamination'),
	(109, 'Quản lý ca phẩu thuật', 'tabItemSurgery'),
	(110, 'Quản lý bảng phân công', 'tabItemAssignment'),
	(111, 'Quản lý phòng ban', 'tabItemDeptMajor'),
	(112, 'Quản lý nhân viên', 'tabItemStaff'),
	(113, 'Quản lý phân quyền', 'tabItemRole'),
	(114, 'Quản lý thuốc', 'tabItemMedicine'),
	(115, 'Quản lý toa thuốc', 'tabItemPrescpition'),
	(116, 'Quản lý phiếu theo dõi sức khỏe', 'tabItemMonitor'),
	(117, 'Quản lý bệnh', 'tabItemDisease'),
	(118, 'Quản lý bệnh án', 'tabItemHealthFile'),
	(119, 'Quản lý giường bệnh', 'tabItemBed'),
	(120, 'Quản lý dịch vụ', 'tabItemService'),
	(121, 'Quản lý vật tư', 'tabItemMaterial'),
	(122, 'Quản lý giấy nhập viện', 'tabItemHospitalization'),
	(123, 'Quản lý giấy xuất viện', 'tabItemDischarged'),
	(124, 'Quản lý chức năng', 'tabItemFunction'),
	(126, 'Quản lý phiếu xét nghiệm', 'tabItemTest');

-- Create table SERVICE
CREATE TABLE "SERVICE" (
	SERVICEID SERIAL PRIMARY KEY,
	SERVICENAME VARCHAR(100) NULL,
	PRICE MONEY NULL
);

ALTER TABLE "SERVICE"
	ADD CONSTRAINT SERVICE_range_check CHECK (SERVICEID >= 100 AND SERVICEID <= 999);

--Thêm dữ liệu cho bảng "SERVICE"
INSERT INTO "SERVICE" (SERVICEID, SERVICENAME, PRICE) VALUES
	(100, 'Khám bệnh', 30000.0000),
	(101, 'Khám bệnh chuyên khoa', 45000.0000),
	(104, 'Phẩu thuật', 1000000.0000),
	(105, 'Chụp X Quang tim phổi', 60000.0000),
	(106, 'Siêu âm bụng tổng quát', 90000.0000),
	(107, 'CT toàn thân', 2000000.0000),
	(108, 'CT sọ não', 800000.0000),
	(109, 'Tổng phân tích tế bào máu', 40000.0000),
	(110, 'Tổng phân tích nước tiểu', 100000.0000),
	(111, 'Điện não', 70000.0000),
	(112, 'Nội soi Thực quản - Dạ dày', 13000000.0000),
	(113, 'Nội soi Trực tràng và Đại tràng Sigma', 170000.0000),
	(114, 'Nội soi tai', 200000.0000),
	(115, 'Nội soi mũi xoang', 80000.0000),
	(116, 'Nội soi thanh quản', 80000.0000),
	(117, 'Sơi cổ tử cung', 60000.0000),
	(118, 'Chụp Xquang cột sống thắt lưng thẳng nghiêng', 70000.0000),
	(119, 'Chụp Xquang sọ thẳng nghiêng', 70000.0000),
	(120, 'Chụp Xquang Blondeau Hirtz', 60000.0000),
	(121, 'Siêu âm Tuyến giáp', 110000.0000),
	(122, 'Siêu âm Vú', 100000.0000),
	(123, 'Siêu âm phần mềm', 90000.0000),
	(124, 'Siêu âm doppler mạch máu', 160000.0000),
	(125, 'Siêu âm thai 3D', 110000.0000),
	(126, 'Siêu âm phụ khoa', 90000.0000),
	(127, 'CT bụng', 800000.0000),
	(128, 'Chụp thêm phim có tiêm thuốc cản quang', 500000.0000),
	(129, 'Nội soi đại tràng ảo', 1200000.0000),
	(130, 'In thêm film CT', 150000.0000),
	(131, 'Giường bệnh hồi sức cấp cứu', 300000.0000),
	(132, 'Giường bệnh phòng VIP', 600000.0000),
	(133, 'Tiêm ngừa viêm gan siêu vi B (Lớn hơn 19 tuổi)', 120000.0000),
	(134, 'Tiêm ngừa uốn ván (SAT)', 40000.0000),
	(135, 'Tiêm ngừa viêm gan siêu vi B (Nhỏ hơn hoặc bằng 19', 120000.0000),
	(136, 'Tiêm ngừa viêm gan siêu vi B cho bé sơ sinh của bà mẹ', 198000.0000),
	(137, 'Vaccin ngừa HPV (dùng thuốc Cervarix)', 825000.0000),
	(138, 'Khám Phụ khoa', 45000.0000),
	(139, 'Khám Sản khoa (Khám thai)', 45000.0000),
	(140, 'Đẻ thường (Không may tầng sinh môn)', 1500000.0000),
	(141, 'Đẻ thường (May thẩm mỹ tầng sinh môn)', 2000000.0000),
	(142, 'Đẻ khó giác hút + may thẩm mỹ tầng sinh môn', 3200000.0000),
	(143, 'Mổ lấy thai lần 1', 3000000.0000),
	(144, 'Mổ lấy thai lần 2', 3500000.0000),
	(145, 'Phẫu thuật nội soi u nang buồng trứng', 3500000.0000),
	(146, 'Hút điều hòa kinh nguyệt (bệnh lý)', 800000.0000);

--Tạo bảng "SERVICEBILLDETAIL"
CREATE TABLE "SERVICEBILLDETAIL" (
    BILLID NUMERIC(8, 0),
    SERVICEID NUMERIC(3, 0),
    QUANTITY INT,
    PRICE MONEY
);
--Đổi kiểu dữ liệu id sang integer
ALTER TABLE "SERVICEBILLDETAIL"
	ALTER COLUMN BILLID TYPE integer USING BILLID::integer,
	ALTER COLUMN SERVICEID TYPE integer USING SERVICEID::integer;

--Giới hạn dữ liệu cho id
ALTER TABLE "SERVICEBILLDETAIL"
	ADD CONSTRAINT BILLID_length_check CHECK (BILLID >= 10000000 AND BILLID <= 99999999),
	ADD CONSTRAINT SERVICEID_length_check CHECK (SERVICEID >= 100 AND SERVICEID <= 999);

--Thêm dữ liệu vào bảng "SERVICEBILLDETAIL"
INSERT INTO "SERVICEBILLDETAIL" (BILLID, SERVICEID, QUANTITY, PRICE) 
VALUES 
    (10000001, 100, 9, 270000.0000),
    (10000003, 105, 1, 60000.0000),
    (10000003, 120, 1, 60000.0000),
    (10000003, 135, 1, 120000.0000),
    (10000006, 101, 1, 45000.0000),
    (10000006, 136, 1, 198000.0000),
    (10000006, 126, 1, 90000.0000),
    (10000009, 100, 1, 30000.0000),
    (10000009, 111, 1, 70000.0000),
    (10000009, 130, 1, 150000.0000),
    (10000009, 129, 1, 1200000.0000),
    (10000010, 100, 1, 30000.0000),
    (10000010, 113, 1, 170000.0000),
    (10000010, 133, 1, 120000.0000),
    (10000011, 124, 1, 160000.0000),
	(10000011, 140, 1, 1500000.0000),
    (10000011, 145, 1, 3500000.0000),
    (10000012, 100, 1, 30000.0000),
    (10000002, 114, 1, 200000.0000),
    (10000012, 136, 1, 198000.0000),
    (10000013, 101, 1, 45000.0000),
    (10000013, 112, 1, 130000.0000),
    (10000013, 137, 1, 825000.0000),
    (10000014, 100, 1, 30000.0000),
    (10000014, 105, 1, 60000.0000),
    (10000014, 123, 1, 90000.0000),
    (10000015, 101, 1, 45000.0000),
    (10000016, 134, 1, 40000.0000),
    (10000016, 129, 1, 1200000.0000),
    (10000017, 124, 2, 320000.0000),
    (10000017, 128, 1, 500000.0000),
    (10000003, 100, 1, 30000.0000),
    (10000008, 131, 10, 3000000.0000),
    (10000008, 145, 10, 35000000.0000),
    (10000018, 142, 10, 32000000.0000),
    (10000001, 104, 1, 1000000.0000),
    (10000012, 112, 1, 13000000.0000),
    (10000013, 114, 1, 200000.0000),
    (10000014, 121, 1, 110000.0000),
    (10000004, 100, 1, 30000.0000),
    (10000014, 104, 1, 1000000.0000),
    (10000009, 100, 1, 30000.0000),
    (10000010, 108, 1, 800000.0000),
    (10000012, 120, 1, 60000.0000),
    (10000013, 111, 1, 70000.0000),
    (10000011, 114, 1, 200000.0000),
    (10000007, 105, 1, 60000.0000),
    (10000018, 100, 1, 30000.0000),
    (10000019, 111, 1, 70000.0000),
    (10000005, 100, 1, 30000.0000),
    (10000012, 114, 1, 200000.0000);


--Tạo bảng "SURGICAL"
CREATE TABLE "SURGICAL" (
    SURGICALID SERIAL PRIMARY KEY,
    PATIENTID numeric(8,0),
    DATE timestamp,
    DESCRIPTION varchar(1000),
    STATE integer
);
--Đổi kiểu dữ liệu id sang integer
ALTER TABLE "SURGICAL"
	ALTER COLUMN PATIENTID TYPE integer USING PATIENTID::integer;

--Giới hạn dữ liệu cho id
ALTER TABLE "SURGICAL"
	ADD CONSTRAINT PATIENTID_length_check CHECK (PATIENTID >= 10000000 AND PATIENTID <= 99999999),
	ADD CONSTRAINT SURGICAL_id_range_check CHECK (SURGICALID >= 10000000 AND SURGICALID <= 99999999);

--Thêm dữ liệu vào bảng "SURGICAL"
INSERT INTO "SURGICAL" (SURGICALID, PATIENTID, DATE, DESCRIPTION, STATE) 
VALUES 
    (10000003, 10000000, '2022-01-01', 'Phẫu thuật nội soi gan để loại bỏ u gan', 1),
    (10000004, 10000001, '2022-01-01', 'Ca phẫu thuật tái tạo cuống họng', 0),
    (10000005, 10000001, '2022-01-01', 'Ca phẫu thuật lấy viên sỏi từ thận', 0),
    (10000006, 10000001, '2022-01-01', 'Ca phẫu thuật ghép động mạch chủ', 0);

--Tạo bảng "SURGICALDETAIL"
CREATE TABLE "SURGICALDETAIL" (
    SURGICALID NUMERIC(8, 0),
    STAFFID NUMERIC(8, 0)
);

--Đổi kiểu dữ liệu id sang integer
ALTER TABLE "SURGICALDETAIL"
	ALTER COLUMN SURGICALID TYPE integer USING SURGICALID::integer,
	ALTER COLUMN STAFFID TYPE integer USING STAFFID::integer;

--Giới hạn dữ liệu cho id
ALTER TABLE "SURGICALDETAIL"
	ADD CONSTRAINT SURGICALID_length_check CHECK (SURGICALID >= 10000000 AND SURGICALID <= 99999999),
	ADD CONSTRAINT STAFFID_id_range_check CHECK (STAFFID >= 10000000 AND STAFFID <= 99999999);

--Thêm dữ liệu vào bảng "SURGICALDETAIL"
INSERT INTO "SURGICALDETAIL" (SURGICALID, STAFFID) 
VALUES 
	(10000003, 10000000),
	(10000003, 10000002),
	(10000004, 10000000),
	(10000004, 10000002),
	(10000005, 10000000),
	(10000005, 10000002),
	(10000006, 10000000);

--Tạo bảng "STAFF"
CREATE TABLE "STAFF" (
    STAFFID SERIAL PRIMARY KEY,
    DEPARTMENTID numeric(3,0),
    MAJORID numeric(3,0),
    ROLEID numeric(3,0),
    PASSWORD char(100),
    FIRSTNAME varchar(100),
    LASTNAME varchar(100),
    BIRTHDAY DATE,
    GENDER integer,
    ICN numeric(9,0),
    ADDRESS varchar(100),
    STATE integer,
	EMAIL varchar(255)
);
-- Tạo hàm để tạo giá trị mặc định cho cột EMAIL
	CREATE OR REPLACE FUNCTION default_email() RETURNS TRIGGER AS $$
	BEGIN
		NEW.EMAIL := NEW.STAFFID || '@gmail.com';
		RETURN NEW;
	END;
	$$ LANGUAGE plpgsql;

-- Thêm ràng buộc để sử dụng hàm tạo giá trị mặc định cho cột EMAIL
	CREATE TRIGGER staff_default_email
	BEFORE INSERT ON "STAFF"
	FOR EACH ROW
	EXECUTE FUNCTION default_email();
	
--Đổi kiểu dữ liệu id sang integer
ALTER TABLE "STAFF"
	ALTER COLUMN DEPARTMENTID TYPE integer USING DEPARTMENTID::integer,
	ALTER COLUMN MAJORID TYPE integer USING MAJORID::integer,
	ALTER COLUMN ROLEID TYPE integer USING ROLEID::integer,
	ALTER COLUMN ICN TYPE integer USING ICN::integer;

--Giới hạn dữ liệu cho id
ALTER TABLE "STAFF"
	ADD CONSTRAINT DEPARTMENTID_length_check CHECK (DEPARTMENTID >= 100 AND DEPARTMENTID <= 999),
	ADD CONSTRAINT MAJORID_length_check CHECK (MAJORID >= 100 AND MAJORID <= 999),
	ADD CONSTRAINT ROLEID_length_check CHECK (ROLEID >= 100 AND ROLEID <= 999),
	ADD CONSTRAINT ICN_length_check CHECK (ICN >= 100000000 AND ICN <= 999999999),
	ADD CONSTRAINT STAFF_length_check CHECK (STAFFID >= 10000000 AND STAFFID <= 99999999);

--Thêm dữ liệu vào bảng "STAFF"
INSERT INTO "STAFF" (STAFFID, DEPARTMENTID, MAJORID, ROLEID, PASSWORD, FIRSTNAME, LASTNAME, BIRTHDAY, GENDER, ICN, ADDRESS, STATE)
VALUES 
	(10000000, 100, 100, 105, 'admin', 'Lâm', 'Nguyễn Văn', '1996-08-01', 0, 273410139, '107/10/1 Bình Giã Tp Vũng Tàu', 1),
    (10000001, 100, 100, 103, 'pass123', 'Tú', 'Nguyễn Hoàng', '1987-06-18', 0, 707070707, '789 Lê Lai, Quảng Ninh', 1),
	(10000002, 102, 101, 100, 'admin', 'Bình', 'Ung Quốc', '1996-09-01', 0, 123456789, '1234', 1),
	(10000003, 113, 106, 102, '273410436', 'Loan', 'Đặng Thị Ngọc', '1996-10-01', 1, 273410436, 'Ktx ĐHQUG', 1),
	(10000004, 100, 100, 103, '273410148', 'Hiệp', 'Nguyễn Thành', '1996-07-01', 0, 273410148, 'KTX DHQG', 1),
	(10000005, 100, 100, 103, '273410149', 'Dũng', 'Đặng Công', '1996-06-01', 0, 273410149, 'KTX DHQG', 1),
	(10000006, 100, 100, 103, '273410150', 'Tiên', 'Lê Thị Cẩm', '1996-05-01', 1, 273410150, 'Bác sĩ', 1),
	(10000007, 100, 100, 103, '273410151', 'Mi', 'Phạm Thị Diễm', '1996-06-01', 1, 273410151, 'KTX DHQG', 1),
	(10000008, 100, 100, 105, 'pass123', 'Hạnh', 'Trần Thị', '1995-08-15', 0, 123456780, '123 Nguyễn Du, Hà Nội', 1),
    (10000009, 102, 101, 100, 'password', 'An', 'Nguyễn Hoàng', '1994-05-25', 0, 987654321, '456 Lê Lợi, TP HCM', 1),
    (10000010, 113, 106, 102, 'secret', 'Bảo', 'Lê Minh', '1997-12-10', 1, 564738291, '789 Điện Biên Phủ, Đà Nẵng', 1),
    (10000011, 100, 100, 103, 'pass123', 'Phong', 'Đỗ Thanh', '1993-04-20', 0, 101010101, '456 Trần Hưng Đạo, Hải Phòng', 1),
    (10000012, 100, 100, 103, 'password', 'Tâm', 'Nguyễn Công', '1992-03-15', 0, 202020202, '789 Ngô Gia Tự, Quảng Ninh', 1),
    (10000013, 100, 100, 103, 'secret', 'Thanh', 'Nguyễn Thị', '1991-07-05', 1, 303030303, '123 Lê Văn Lương, Hà Nội', 1),
    (10000014, 100, 100, 103, 'pass123', 'Tuấn', 'Vũ Quang', '1990-09-12', 0, 404040404, '456 Trần Hưng Đạo, TP HCM', 1),
    (10000015, 100, 100, 103, 'password', 'Trang', 'Hoàng Thị', '1989-01-30', 1, 505050505, '789 Nguyễn Huệ, Đà Nẵng', 1),
    (10000016, 100, 100, 103, 'secret', 'Duy', 'Lê Văn', '1988-11-20', 0, 606060606, '123 Lê Lợi, Hải Phòng', 1);
	

--Tạo bảng "HIC"
CREATE TABLE "HIC" (
    HICID numeric(9, 0) NOT NULL,
    PATIENTID numeric(8, 0) NOT NULL,
    EXPIREDATE timestamp NULL,
    ISSUEDATE timestamp NULL,
    CONSTRAINT PK_HIC PRIMARY KEY (HICID)
);
ALTER TABLE "HIC"
	ALTER COLUMN PATIENTID TYPE integer USING PATIENTID::integer,
	ALTER COLUMN HICID TYPE integer USING HICID::integer;

--Giới hạn dữ liệu cho id
ALTER TABLE "HIC"
	ADD CONSTRAINT HICID_length_check CHECK (HICID >= 100000000 AND HICID <= 999999999),
	ADD CONSTRAINT PATIENTID_length_check CHECK (PATIENTID >= 10000000 AND PATIENTID <= 99999999);

--Thêm dữ liệu vào bảng "HIC"
INSERT INTO "HIC" (HICID, PATIENTID, EXPIREDATE, ISSUEDATE) 
VALUES 
    (273410137, 10000002, '1973-09-15 00:00:00', '1973-05-15 00:00:00'),
    (273410138, 10000003, '1973-10-15 00:00:00', '1973-05-15 00:00:00'),
    (273410139, 10000004, '1973-11-15 00:00:00', '1973-05-15 00:00:00'),
    (273410140, 10000005, '1973-12-15 00:00:00', '1973-05-15 00:00:00'),
    (273410141, 10000007, '1974-01-15 00:00:00', '1973-05-15 00:00:00'),
    (273410142, 10000008, '1974-02-15 00:00:00', '1973-05-15 00:00:00'),
    (273410143, 10000009, '1974-03-15 00:00:00', '1973-05-15 00:00:00');
--Tạo bảng "HEATHFILE"
CREATE TABLE "HEATHFILE" (
    HEATHFILEID SERIAL PRIMARY KEY,
    PATIENTID NUMERIC(8, 0),
    DATE TIMESTAMP,
    PATIENTSTATE VARCHAR(1000),
    PREHISTORY VARCHAR(1000),
    DISEASE VARCHAR(1000),
    TREATMENT VARCHAR(1000)
);
--Đổi kiểu dữ liệu id sang integer
ALTER TABLE "HEATHFILE"
	ALTER COLUMN PATIENTID TYPE integer USING PATIENTID::integer;

--Giới hạn dữ liệu cho id
ALTER TABLE "HEATHFILE"
	ADD CONSTRAINT HEATHFILE_length_check CHECK (HEATHFILEID >= 10000000 AND HEATHFILEID <= 99999999),
	ADD CONSTRAINT PATIENTID_length_check CHECK (PATIENTID >= 10000000 AND PATIENTID <= 99999999);

--Thêm dữ liệu vào bảng "HEATHFILE"
INSERT INTO "HEATHFILE" (HEATHFILEID, PATIENTID, DATE, PATIENTSTATE, PREHISTORY, DISEASE, TREATMENT) 
VALUES
  (10000000, 10000002, '2024-04-27 00:00:00', 'Suy tim', 'Không', 'Hở van tim', 'Phẩu thuật'),
  (10000001, 10000003, '2024-04-27 00:00:00', 'Đã bớt đau bụng', 'Viêm dạ dày', 'Loét dạ dày', 'Phẩu thuật'),
  (10000002, 10000004, '2024-04-27 00:00:00', 'Suy tim', 'Không', 'Hở van tim', 'Phẩu thuật'),
  (10000003, 10000005, '2024-04-27 00:00:00', 'Đã bớt đau bụng', 'Viêm dạ dày', 'Loét dạ dày', 'Phẩu thuật'),
  (10000004, 10000006, '2024-04-27 00:00:00', 'Suy tim', 'Không', 'Hở van tim', 'Phẩu thuật');

--Tạo bảng "HEATHMONITORINGNOTE"
CREATE TABLE "HEATHMONITORINGNOTE" (
    HNID SERIAL PRIMARY KEY,
    PATIENTID numeric(8,0),
    STAFFID numeric(8,0),
    DATE timestamp,
    WEIGHT varchar(100),
    BLOODPRESSURE varchar(100),
    PATIENTSTATE varchar(1000)
);

--Đổi kiểu dữ liệu id sang integer
ALTER TABLE "HEATHMONITORINGNOTE"
	ALTER COLUMN PATIENTID TYPE integer USING PATIENTID::integer,
	ALTER COLUMN STAFFID TYPE integer USING STAFFID::integer;

--Giới hạn dữ liệu cho id
ALTER TABLE "HEATHMONITORINGNOTE"
	ADD CONSTRAINT HEATHMONITORINGNOTE_length_check CHECK (HNID >= 10000000 AND HNID <= 99999999),
	ADD CONSTRAINT STAFFID_length_check CHECK (STAFFID >= 10000000 AND STAFFID <= 99999999),
	ADD CONSTRAINT PATIENTID_length_check CHECK (PATIENTID >= 10000000 AND PATIENTID <= 99999999);

--Thêm dữ liệu vào bảng "HIC"
INSERT INTO "HEATHMONITORINGNOTE" (HNID, PATIENTID, STAFFID, DATE, WEIGHT, BLOODPRESSURE, PATIENTSTATE)
VALUES 
    (10000001, 10000001, 10000001, '2022-04-15 08:30:00', '65 kg', '120/80', 'Bình thường'),
    (10000002, 10000002, 10000002, '2022-04-15 09:15:00', '70 kg', '130/90', 'Bình thường'),
    (10000003, 10000003, 10000003, '2022-04-15 10:00:00', '68 kg', '125/85', 'Cần kiểm tra'),
    (10000004, 10000004, 10000004, '2022-04-15 10:45:00', '75 kg', '135/95', 'Cần can thiệp'),
    (10000005, 10000005, 10000005, '2022-04-15 11:30:00', '72 kg', '128/88', 'Cần nhập viện'),
    (10000006, 10000006, 10000006, '2022-04-15 12:15:00', '67 kg', '122/82', 'Đang điều trị'),
    (10000007, 10000007, 10000007, '2022-04-15 13:00:00', '80 kg', '140/100', 'Đã phục hồi');

--Tạo bảng "EXAMINATIONCERTIFICATE"
CREATE TABLE "EXAMINATIONCERTIFICATE" (
    ECID SERIAL PRIMARY KEY,
    PATIENTID numeric(8,0),
    STAFFID numeric(8,0),
    DATE timestamp,
    RESULT varchar(1000),
    STATE integer
);
--Đổi kiểu dữ liệu id sang integer
ALTER TABLE "EXAMINATIONCERTIFICATE"
	ALTER COLUMN PATIENTID TYPE integer USING PATIENTID::integer,
	ALTER COLUMN STAFFID TYPE integer USING STAFFID::integer;

--Giới hạn dữ liệu cho id
ALTER TABLE "EXAMINATIONCERTIFICATE"
	ADD CONSTRAINT PATIENTID_length_check CHECK (PATIENTID >= 10000000 AND PATIENTID <= 99999999),
	ADD CONSTRAINT STAFFID_length_check CHECK (STAFFID >= 10000000 AND STAFFID <= 99999999),
	ADD CONSTRAINT ECID_length_check CHECK (ECID >= 10000000 AND ECID <= 99999999);

--Thêm dữ liệu vào bảng "EXAMINATIONCERTIFICATE"
INSERT INTO "EXAMINATIONCERTIFICATE" (ECID, PATIENTID, STAFFID, DATE, RESULT, STATE) 
VALUES 
    (10000001, 10000002, 10000001, '2024-02-01 09:00:00', 'Chưa có kết quả', 0),
    (10000002, 10000003, 10000002, '2024-02-02 10:30:00', 'Không có dấu hiệu bất thường', 1),
    (10000003, 10000004, 10000003, '2024-02-03 11:45:00', 'Đau họng', 1),
    (10000004, 10000005, 10000004, '2024-02-04 13:15:00', 'Suy giảm sức đề kháng', 1),
    (10000005, 10000006, 10000005, '2024-02-05 14:30:00', 'Viêm gan A', 1),
    (10000006, 10000007, 10000006, '2024-02-06 15:45:00', 'Đau rát âm đạo', 0),
    (10000007, 10000008, 10000007, '2024-02-07 16:00:00', 'Chưa có kết quả', 0),
    (10000008, 10000009, 10000008, '2024-02-08 17:00:00', 'Khó thở', 1),
    (10000009, 10000010, 10000009, '2024-02-09 18:00:00', 'Dấu hiệu bình thường', 1),
    (10000010, 10000011, 10000010, '2024-02-10 19:00:00', 'Không có dấu hiệu bất thường', 1);

--Tạo bảng "DISCHARGEDCERTIFICATE"
CREATE TABLE "DISCHARGEDCERTIFICATE" (
	DCID SERIAL PRIMARY KEY,
    STAFFID numeric(8,0),
    PATIENTID numeric(8,0),
    DATE timestamp,
    STATE integer
);
--Đổi kiểu dữ liệu id sang integer
ALTER TABLE "DISCHARGEDCERTIFICATE"
	ALTER COLUMN STAFFID TYPE integer USING STAFFID::integer,
	ALTER COLUMN PATIENTID TYPE integer USING PATIENTID::integer;

--Giới hạn dữ liệu cho id
ALTER TABLE "DISCHARGEDCERTIFICATE"
	ADD CONSTRAINT STAFFID_length_check CHECK (STAFFID >= 10000000 AND STAFFID <= 99999999),
	ADD CONSTRAINT PATIENTID_length_check CHECK (PATIENTID >= 10000000 AND PATIENTID <= 99999999),
	ADD CONSTRAINT DCID_length_check CHECK (DCID >= 10000000 AND DCID <= 99999999);

--Thêm dữ liệu vào bảng "EXAMINATIONCERTIFICATE"
INSERT INTO "DISCHARGEDCERTIFICATE" (DCID, STAFFID, PATIENTID, DATE, STATE) 
VALUES 
    (10000001, 10000001, 10000001, '2024-04-01 10:00:00', 1),
    (10000002, 10000002, 10000002, '2024-04-02 11:00:00', 0),
    (10000003, 10000003, 10000003, '2024-04-03 12:00:00', 1),
    (10000004, 10000004, 10000004, '2024-04-04 13:00:00', 0),
    (10000005, 10000005, 10000005, '2024-04-05 14:00:00', 1),
    (10000006, 10000006, 10000036, '2024-04-06 15:00:00', 1),
    (10000007, 10000007, 10000027, '2024-04-07 16:00:00', 0),
    (10000008, 10000008, 10000018, '2024-04-08 17:00:00', 1),
    (10000009, 10000009, 10000029, '2024-04-09 18:00:00', 0),
    (10000010, 10000010, 10000030, '2024-04-10 19:00:00', 1);

--Tạo bảng "ASSIGNMENT"
CREATE TABLE "ASSIGNMENT" (
    ASSIGNID SERIAL PRIMARY KEY,
    DATE timestamp,
    DISCHARGEDDATE timestamp,
    HOPITALIZATEDATE timestamp,
    PATIENTID numeric(8,0)
);
--Đổi kiểu dữ liệu id sang integer
ALTER TABLE "ASSIGNMENT"
ALTER COLUMN PATIENTID TYPE integer USING PATIENTID::integer;

--Giới hạn dữ liệu cho id
ALTER TABLE "ASSIGNMENT"
ADD CONSTRAINT ASSIGNID_length_check CHECK (ASSIGNID >= 10000000 AND ASSIGNID <= 99999999);
ALTER TABLE "ASSIGNMENT"
ADD CONSTRAINT patientid_length_check CHECK (PATIENTID >= 10000000 AND PATIENTID <= 99999999);

--Thêm dữ liệu vào bảng "ASSIGNMENT"
INSERT INTO "ASSIGNMENT" (ASSIGNID, DATE, DISCHARGEDDATE, HOPITALIZATEDATE, PATIENTID) 
VALUES
  (10000001, '2024-04-20 10:00:00', '2024-04-22 15:00:00', '2024-04-20 08:00:00', 10000001),
  (10000002, '2024-04-21 09:00:00', '2024-04-23 14:00:00', '2024-04-21 07:00:00', 10000002),
  (10000003, '2024-04-22 08:00:00', '2024-04-24 13:00:00', '2024-04-22 06:00:00', 10000003),
  (10000004, '2024-04-23 07:00:00', '2024-04-25 12:00:00', '2024-04-23 05:00:00', 10000004),
  (10000005, '2024-04-24 06:00:00', '2024-04-26 11:00:00', '2024-04-24 04:00:00', 10000005),
  (10000006, '2024-04-25 05:00:00', '2024-04-27 10:00:00', '2024-04-25 03:00:00', 10000006),
  (10000007, '2024-04-26 04:00:00', '2024-04-28 09:00:00', '2024-04-26 02:00:00', 10000007);
  
--Tạo bảng "ASSIGNMENTDETAIL"
CREATE TABLE "ASSIGNMENTDETAIL" (
    ASSIGNID numeric(8,0),
    STAFFID numeric(8,0)
);

--Đổi kiểu dữ liệu id sang integer
ALTER TABLE "ASSIGNMENTDETAIL"
	ALTER COLUMN ASSIGNID TYPE integer USING ASSIGNID::integer,
	ALTER COLUMN STAFFID TYPE integer USING STAFFID::integer;

--Giới hạn dữ liệu cho id
ALTER TABLE "ASSIGNMENTDETAIL"
	ADD CONSTRAINT ASSIGNID_length_check CHECK (ASSIGNID >= 10000000 AND ASSIGNID <= 99999999),
	ADD CONSTRAINT STAFFID_length_check CHECK (STAFFID >= 10000000 AND STAFFID <= 99999999);

--Thêm dữ liệu vào bảng "ASSIGNMENTDETAIL"
INSERT INTO "ASSIGNMENTDETAIL" (ASSIGNID, STAFFID) 
VALUES
  (10000001, 10000000),
  (10000002, 10000002),
  (10000003, 10000003),
  (10000004, 10000004),
  (10000005, 10000000),
  (10000006, 10000006),
  (10000007, 10000007)

--Tạo bảng "HOSPITALIZATIONCERTIFICATE"
CREATE TABLE "HOSPITALIZATIONCERTIFICATE" (
    HCID SERIAL PRIMARY KEY,
    PATIENTID numeric(8,0),
    STAFFID numeric(8,0),
    REASON varchar(1000),
    DATE timestamp,
    STATE integer
);

--Đổi kiểu dữ liệu id sang integer
ALTER TABLE "HOSPITALIZATIONCERTIFICATE"
	ALTER COLUMN PATIENTID TYPE integer USING PATIENTID::integer,
	ALTER COLUMN STAFFID TYPE integer USING STAFFID::integer;

--Giới hạn dữ liệu cho id
ALTER TABLE "HOSPITALIZATIONCERTIFICATE"
	ADD CONSTRAINT PATIENTID_length_check CHECK (PATIENTID >= 10000000 AND PATIENTID <= 99999999),
	ADD CONSTRAINT STAFFID_length_check CHECK (STAFFID >= 10000000 AND STAFFID <= 99999999),
	ADD CONSTRAINT HCID_length_check CHECK (HCID >= 10000000 AND HCID <= 99999999);

--Thêm dữ liệu vào bảng "HOSPITALIZATIONCERTIFICATE"
INSERT INTO "HOSPITALIZATIONCERTIFICATE" (HCID, PATIENTID, STAFFID, REASON, DATE, STATE)
VALUES 
	(10000011, 10000006, 10000001, 'Nhồi máu cơ tim cấp tính', '2023-03-05 00:00:00', 1),
	(10000012, 10000007, 10000001, 'Ngộ độc thực phẩm', '2023-03-05 00:00:00', 1),
	(10000013, 10000008, 10000002, 'Đau thắt ngực', '2023-03-06 00:00:00', 1),
	(10000014, 10000009, 10000002, 'Đau bụng dữ dội', '2023-03-07 00:00:00', 1),
	(10000015, 10000010, 10000003, 'Tăng huyết áp', '2023-03-08 00:00:00', 1),
	(10000016, 10000011, 10000003, 'Suy tim', '2023-03-08 00:00:00', 1),
	(10000017, 10000012, 10000004, 'Viêm tai giữa', '2023-03-09 00:00:00', 1),
	(10000018, 10000013, 10000004, 'Cảm lạnh', '2023-03-10 00:00:00', 1),
	(10000019, 10000014, 10000005, 'Chấn thương não', '2023-03-11 00:00:00', 1),
	(10000020, 10000015, 10000005, 'Gãy xương bàn chân', '2023-03-12 00:00:00', 1);

-- Create table TESTTYPE
CREATE TABLE "TESTTYPE" (
    TESTTYPEID SERIAL PRIMARY KEY,
    TYPENAME varchar(100)
);
ALTER TABLE "TESTTYPE"
	ADD CONSTRAINT TESTTYPE_range_check CHECK (TESTTYPEID >= 100 AND TESTTYPEID <= 999);

--Thêm dữ liệu cho bảng "TESTTYPE"
INSERT INTO "TESTTYPE" (TESTTYPEID, TYPENAME) 
VALUES 
	(100, 'Xét nghiệm máu'),
	(101, 'Xét nghiệm nước tiểu'),
	(102, 'Chụp X quang'),
	(103, 'Siêu âm'),
    (104, 'MRI'),
    (105, 'EKG'),
    (106, 'CT scan');

--Tạo bảng "TESTDETAIL"
CREATE TABLE "TESTDETAIL" (
    TESTTYPEID NUMERIC(3, 0),
    TCID NUMERIC(8, 0),
    RESULT VARCHAR(1000)
);
--Đổi kiểu dữ liệu id sang integer
ALTER TABLE "TESTDETAIL"
	ALTER COLUMN TESTTYPEID TYPE integer USING TESTTYPEID::integer,
	ALTER COLUMN TCID TYPE integer USING TCID::integer;

--Giới hạn dữ liệu cho id
ALTER TABLE "TESTDETAIL"
	ADD CONSTRAINT TESTTYPEID_length_check CHECK (TESTTYPEID >= 100 AND TESTTYPEID <= 999),
	ADD CONSTRAINT TCID_length_check CHECK (TCID >= 10000000 AND TCID <= 99999999);

--Thêm dữ liệu vào bảng "TESTDETAIL"
INSERT INTO "TESTDETAIL" (TESTTYPEID, TCID, RESULT)
VALUES 
    (100, 10000001, 'Kết quả xét nghiệm huyết áp bình thường'),
    (101, 10000001, 'Phát hiện mức độ cholesterol cao'),
    (101, 10000002, 'Kết quả xét nghiệm đường huyết bình thường'),
    (100, 10000003, 'Chưa thực hiện xét nghiệm'),
    (101, 10000003, 'Chưa thực hiện xét nghiệm'),
    (102, 10000003, 'Chưa thực hiện xét nghiệm'),
    (102, 10000004, 'Dương tính với COVID-19'),
    (100, 10000005, 'Âm tính với virus cúm'),
    (101, 10000005, 'Dương tính với vi khuẩn streptococcus'),
    (102, 10000005, 'Âm tính với vi khuẩn lao'),
    (100, 10000006, 'Kết quả xét nghiệm chức năng gan bình thường'),
    (101, 10000006, 'Phát hiện mức độ bilirubin cao'),
    (102, 10000006, 'Kết quả xét nghiệm chức năng thận bình thường'),
    (100, 10000007, 'Kết quả xét nghiệm hormone tuyến giáp bình thường'),
    (101, 10000007, 'Phát hiện mức độ hormone kích thích tuyến giáp cao');

--Tạo bảng "TESTCERTIFICATE"
CREATE TABLE "TESTCERTIFICATE" (
    TCID SERIAL PRIMARY KEY,
    PATIENTID NUMERIC(8, 0),
    STAFFID NUMERIC(8, 0),
    DATE TIMESTAMP,
    STATE INT
);

--Đổi kiểu dữ liệu id sang integer
ALTER TABLE "TESTCERTIFICATE"
	ALTER COLUMN PATIENTID TYPE integer USING PATIENTID::integer,
	ALTER COLUMN STAFFID TYPE integer USING STAFFID::integer;

--Giới hạn dữ liệu cho id
ALTER TABLE "TESTCERTIFICATE"
	ADD CONSTRAINT PATIENTID_length_check CHECK (PATIENTID >= 10000000 AND PATIENTID <= 99999999),
	ADD CONSTRAINT STAFFID_length_check CHECK (STAFFID >= 10000000 AND STAFFID <= 99999999),
	ADD CONSTRAINT TCID_length_check CHECK (TCID >= 10000000 AND TCID <= 99999999);

--Thêm dữ liệu vào bảng "TESTCERTIFICATE"
INSERT INTO "TESTCERTIFICATE" (TCID, PATIENTID, STAFFID, DATE, STATE) 
VALUES 
  (10000001, 10000002, 10000001, '2022-01-10 00:00:00', 1),
  (10000002, 10000002, 10000001, '2022-01-12 00:00:00', 1),
  (10000003, 10000003, 10000002, '2022-01-15 00:00:00', 0),
  (10000004, 10000003, 10000002, '2022-01-18 00:00:00', 1),
  (10000005, 10000004, 10000003, '2022-01-20 00:00:00', 0),
  (10000006, 10000004, 10000003, '2022-01-22 00:00:00', 1),
  (10000007, 10000002, 10000004, '2022-01-25 00:00:00', 0),
  (10000008, 10000005, 10000004, '2022-01-28 00:00:00', 1),
  (10000009, 10000006, 10000005, '2022-01-30 00:00:00', 0),
  (10000010, 10000006, 10000005, '2022-02-02 00:00:00', 1);

--Tạo bảng "PRESCRIPTION"
CREATE TABLE "PRESCRIPTION" (
    PRESCRIPTIONID SERIAL PRIMARY KEY,
    STAFFID numeric(8,0),
    PATIENTID numeric(8,0),
    DATE timestamp
);

--Đổi kiểu dữ liệu id sang integer
ALTER TABLE "PRESCRIPTION"
	ALTER COLUMN STAFFID TYPE integer USING STAFFID::integer,
	ALTER COLUMN PATIENTID TYPE integer USING PATIENTID::integer;

--Giới hạn dữ liệu cho id
ALTER TABLE "PRESCRIPTION"
	ADD CONSTRAINT PRESCRIPTIONID_length_check CHECK (PRESCRIPTIONID >= 10000000 AND PRESCRIPTIONID <= 99999999),
	ADD CONSTRAINT STAFFID_length_check CHECK (STAFFID >= 10000000 AND STAFFID <= 99999999),
	ADD CONSTRAINT PATIENTID_length_check CHECK (PATIENTID >= 10000000 AND PATIENTID <= 99999999);

--Thêm dữ liệu vào bảng "PRESCRIPTION"
INSERT INTO "PRESCRIPTION" (PRESCRIPTIONID, STAFFID, PATIENTID, DATE) 
VALUES 
	(10000001, 10000001, 10000011, '2024-04-29 00:00:00'),
	(10000002, 10000002, 10000003, '2024-04-29 00:00:00'),
	(10000003, 10000003, 10000002, '2024-04-29 00:00:00'),
	(10000004, 10000004, 10000030, '2024-04-30 00:00:00'),
	(10000005, 10000005, 10000003, '2024-04-30 00:00:00'),
	(10000006, 10000006, 10000004, '2024-04-30 00:00:00'),
	(10000007, 10000007, 10000005, '2024-04-30 00:00:00'),
	(10000008, 10000008, 10000007, '2024-04-30 00:00:00'),
	(10000009, 10000009, 10000015, '2024-04-30 00:00:00'),
	(10000010, 10000010, 10000013, '2024-04-29 00:00:00'),
	(10000011, 10000011, 10000012, '2024-05-01 00:00:00'),
    (10000012, 10000012, 10000013, '2024-05-01 00:00:00'),
    (10000013, 10000013, 10000014, '2024-05-01 00:00:00'),
    (10000014, 10000014, 10000015, '2024-05-02 00:00:00'),
    (10000015, 10000015, 10000016, '2024-05-02 00:00:00'),
    (10000016, 10000016, 10000017, '2024-05-02 00:00:00'),
    (10000017, 10000000, 10000031, '2024-05-03 00:00:00'),
    (10000018, 10000002, 10000032, '2024-05-03 00:00:00'),
    (10000019, 10000003, 10000040, '2024-05-03 00:00:00'),
    (10000020, 10000004, 10000004, '2024-05-03 00:00:00');

--Tạo bảng "RENTMATERIALBILLDETAIL"
CREATE TABLE "RENTMATERIALBILLDETAIL" (
    BILLID NUMERIC(8, 0) NULL,
    MATERIALID NUMERIC(3, 0) NOT NULL,
    QUANTITY INT NULL,
    PRICE MONEY NULL
);

--Đổi kiểu dữ liệu id sang integer
ALTER TABLE "RENTMATERIALBILLDETAIL"
	ALTER COLUMN BILLID TYPE integer USING BILLID::integer,
	ALTER COLUMN MATERIALID TYPE integer USING MATERIALID::integer;

--Giới hạn dữ liệu cho id
ALTER TABLE "RENTMATERIALBILLDETAIL"
	ADD CONSTRAINT BILLID_length_check CHECK (BILLID >= 10000000 AND BILLID <= 99999999),
	ADD CONSTRAINT MATERIALID_length_check CHECK (MATERIALID >= 100 AND MATERIALID <= 999);

--Thêm dữ liệu vào bảng "RENTMATERIALBILLDETAIL"
INSERT INTO "RENTMATERIALBILLDETAIL" (BILLID, MATERIALID, QUANTITY, PRICE) 
VALUES 
    (10000002, 101, 1, 15000.0000),
    (10000002, 104, 1, 20000.0000),
    (10000002, 106, 1, 10000.0000),
    (10000002, 105, 2, 20000.0000),
    (10000002, 105, 2, 30000.0000),
    (10000004, 101, 2, 30000.0000),
    (10000004, 106, 2, 20000.0000),
    (10000004, 105, 2, 40000.0000),
    (10000005, 101, 1, 15000.0000),
    (10000005, 104, 1, 20000.0000),
    (10000005, 105, 1, 15000.0000),
    (10000007, 107, 1, 10000.0000),
    (10000007, 107, 1, 15000.0000),
    (10000007, 106, 1, 10000.0000),
    (10000008, 108, 1, 15000.0000),
    (10000008, 108, 1, 10000.0000);

--Tạo bảng "PRESCRIPTIONDETAIL"
CREATE TABLE "PRESCRIPTIONDETAIL" (
	MEDICINEID numeric(6, 0) NULL,
	PRESCRIPTIONID numeric(8, 0) NULL,
	QUANTITY int NULL,
	INSTRUCTION varchar(100) NULL
);

--Đổi kiểu dữ liệu id sang integer
ALTER TABLE "PRESCRIPTIONDETAIL"
	ALTER COLUMN MEDICINEID TYPE integer USING MEDICINEID::integer,
	ALTER COLUMN PRESCRIPTIONID TYPE integer USING PRESCRIPTIONID::integer;

--Giới hạn dữ liệu cho id
ALTER TABLE "PRESCRIPTIONDETAIL"
	ADD CONSTRAINT MEDICINEID_length_check CHECK (MEDICINEID >= 100000 AND MEDICINEID <= 999999),
	ADD CONSTRAINT PRESCRIPTIONID_length_check CHECK (PRESCRIPTIONID >= 10000000 AND PRESCRIPTIONID <= 99999999);

--Thêm dữ liệu vào bảng "PRESCRIPTIONDETAIL"
INSERT INTO "PRESCRIPTIONDETAIL" (MEDICINEID, PRESCRIPTIONID, QUANTITY, INSTRUCTION)
VALUES 
	(100001, 10000001, 1, 'Uống sau khi ăn vào buổi sáng và hạn chế hoạt động mạnh.'),
	(100003, 10000002, 2, 'Uống trước khi ăn vào buổi tối và cần nghỉ ngơi đủ giấc.'),
	(100002, 10000003, 1, 'Uống trước khi ăn vào buổi sáng và tăng cường vận động nhẹ nhàng.'),
	(100004, 10000004, 3, 'Uống sau khi ăn vào buổi tối và cần tập thể dục đều đặn.'),
	(100005, 10000005, 1, 'Uống sau khi ăn vào buổi sáng và cần giữ tư thế đúng khi ngồi làm việc.'),
	(100007, 10000006, 2, 'Uống sau khi ăn vào buổi tối và cần tạo điều kiện để tâm trí thư giãn.'),
	(100006, 10000007, 1, 'Uống trước khi ăn vào buổi sáng và cần dưỡng sức bằng giấc ngủ đủ.'),
	(100001, 10000008, 1, 'Uống sau khi ăn vào buổi tối và hạn chế tiếp xúc với môi trường ô nhiễm.'),
	(100002, 10000009, 2, 'Uống trước khi ăn vào buổi sáng và thường xuyên ra ngoài để tận hưởng không khí trong lành.'),
	(100003, 10000010, 2, 'Uống sau khi ăn vào buổi tối và cần dành thời gian cho các hoạt động giải trí.'),
	(100005, 10000011, 1, 'Uống trước khi ăn vào buổi sáng và cần duy trì chế độ ăn uống cân đối.'),
	(100007, 10000012, 1, 'Uống sau khi ăn vào buổi tối và cần hạn chế thức ăn nhanh và thức uống có ga.'),
	(100008, 10000013, 2, 'Uống sau khi ăn vào buổi sáng và cần giữ tư thế đúng khi làm việc.'),
	(100009, 10000014, 3, 'Uống trước khi ăn vào buổi tối và cần dành thời gian cho việc thư giãn.'),
	(100010, 10000015, 1, 'Uống trước khi ăn vào buổi sáng và cần tập thể dục đều đặn.'),
	(100011, 10000016, 2, 'Uống sau khi ăn vào buổi tối và hạn chế tiếp xúc với thiết bị điện tử trước khi đi ngủ.'),
	(100012, 10000017, 1, 'Uống trước khi ăn vào buổi sáng và cần duy trì giấc ngủ đều đặn.'),
	(100013, 10000018, 1, 'Uống sau khi ăn vào buổi tối và cần hạn chế thức ăn nặng trước khi đi ngủ.'),
	(100014, 10000019, 2, 'Uống sau khi ăn vào buổi sáng và cần thực hiện các bài tập thư giãn.'),
	(100015, 10000020, 3, 'Uống trước khi ăn vào buổi tối và cần dành thời gian cho việc hít thở sâu để giảm căng thẳng.');

--Tạo bảng "MEDICINEBILLDETAIL"
CREATE TABLE "MEDICINEBILLDETAIL" (
    MEDICINEID NUMERIC(6, 0) NOT NULL,
    BILLID NUMERIC(8, 0) NULL,
    QUANTITY INT NULL,
    PRICE MONEY NULL
);

--Đổi kiểu dữ liệu id sang integer
ALTER TABLE "MEDICINEBILLDETAIL"
	ALTER COLUMN MEDICINEID TYPE integer USING MEDICINEID::integer,
	ALTER COLUMN BILLID TYPE integer USING BILLID::integer;

--Giới hạn dữ liệu cho id
ALTER TABLE "MEDICINEBILLDETAIL"
	ADD CONSTRAINT MEDICINEID_length_check CHECK (MEDICINEID >= 100000 AND MEDICINEID <= 999999),
	ADD CONSTRAINT BILLID_length_check CHECK (BILLID >= 10000000 AND BILLID <= 99999999);

--Thêm dữ liệu vào bảng "MEDICINEBILLDETAIL"
INSERT INTO "MEDICINEBILLDETAIL" (MEDICINEID, BILLID, QUANTITY, PRICE)
VALUES 
	(100001, 10000001, 1, 65000.0000),
	(100002, 10000002, 2, 30000.0000),
	(100003, 10000003, 1, 65000.0000),
	(100006, 10000004, 11, 176000.0000),
	(100004, 10000005, 1, 65000.0000),
	(100005, 10000006, 2, 30000.0000),
	(100007, 10000007, 10, 150000.0000),
	(100009, 10000008, 12, 480000.0000),
	(100008, 10000009, 10, 150000.0000),
	(100010, 10000010, 12, 480000.0000),
	(100011, 10000011, 10, 650000.0000),
	(100012, 10000012, 1, 65000.0000),
	(100014, 10000013, 2, 30000.0000),
	(100013, 10000014, 1, 65000.0000),
	(100015, 10000015, 2, 132000.0000);

--------- RÀNG BUỘC -----------
-- ForeignKey [FK_ASSIGNMENT_PATIENT] --
ALTER TABLE "ASSIGNMENT" ADD CONSTRAINT FK_ASSIGNMENT_PATIENT
	FOREIGN KEY (PATIENTID) REFERENCES "PATIENT"(PATIENTID)
	ON DELETE CASCADE;
-- ForeignKey [FK_ASSIGNME_RELATIONS_ASSIGNME] --
ALTER TABLE "ASSIGNMENTDETAIL" ADD CONSTRAINT FK_ASSIGNMENTDETAIL_ASSIGNMENT
	FOREIGN KEY (ASSIGNID) REFERENCES "ASSIGNMENT"(ASSIGNID)
	ON DELETE CASCADE;

-- ForeignKey [FK_ASSIGNME_RELATIONS_STAFF] --
ALTER TABLE "ASSIGNMENTDETAIL" ADD CONSTRAINT FK_ASSIGNMENTDETAIL_STAFF
	FOREIGN KEY (STAFFID) REFERENCES "STAFF"(STAFFID)
	ON DELETE CASCADE;

-- ForeignKey [FK_BILL_RELATIONS_BILLTYPE] --
ALTER TABLE "BILL" ADD CONSTRAINT FK_BILL_BILLTYPE
	FOREIGN KEY (BILLTYPEID) REFERENCES "BILLTYPE"(BILLTYPEID)
	ON DELETE CASCADE;

-- ForeignKey [FK_BILL_RELATIONS_PATIENT] --
ALTER TABLE "BILL" ADD CONSTRAINT FK_BILL_PATIENT
	FOREIGN KEY (PATIENTID) REFERENCES "PATIENT"(PATIENTID)
	ON DELETE CASCADE;
	
-- ForeignKey [FK_BILL_RELATIONS_STAFF] --
ALTER TABLE "BILL" ADD CONSTRAINT FK_BILL_STAFF
	FOREIGN KEY (STAFFID) REFERENCES "STAFF"(STAFFID)
	ON DELETE CASCADE;

-- ForeignKey [FK_STAFF_RELATIONS_DISCHARGEDCERTIFICATE] --
ALTER TABLE "DISCHARGEDCERTIFICATE" ADD CONSTRAINT FK_DISCHARGEDCERTIFICATE_STAFF
	FOREIGN KEY (STAFFID) REFERENCES "STAFF"(STAFFID)
	ON DELETE CASCADE;
	
-- ForeignKey [FK_EXAMINATIONCERTIFICATE_RELATIONS_PATIENT] --
ALTER TABLE "EXAMINATIONCERTIFICATE" ADD CONSTRAINT FK_EXAMINATIONCERTIFICATE_PATIENT
	FOREIGN KEY (PATIENTID) REFERENCES "PATIENT"(PATIENTID)
	ON DELETE CASCADE;

-- ForeignKey [FK_EXAMINATIONCERTIFICATE_RELATIONS_STAFF] --
ALTER TABLE "EXAMINATIONCERTIFICATE" ADD CONSTRAINT FK_EXAMINATIONCERTIFICATE_STAFF
	FOREIGN KEY (STAFFID) REFERENCES "STAFF"(STAFFID)
	ON DELETE CASCADE;
	
-- ForeignKey [FK_HEATHFILE_RELATIONS_PATIENT] --
ALTER TABLE "HEATHFILE" ADD CONSTRAINT FK_HEATHFILE_PATIENT
	FOREIGN KEY (PATIENTID) REFERENCES "PATIENT"(PATIENTID)
	ON DELETE CASCADE;	

-- ForeignKey [FK_HEATHMONITORINGNOTE_RELATIONS_PATIENT] --
ALTER TABLE "HEATHMONITORINGNOTE" ADD CONSTRAINT FK_HEATHMONITORINGNOTE_PATIENT
	FOREIGN KEY (PATIENTID) REFERENCES "PATIENT"(PATIENTID)
	ON DELETE CASCADE;	
	
-- ForeignKey [FK_HEATHMONITORINGNOTE_RELATIONS_STAFF] --
ALTER TABLE "HEATHMONITORINGNOTE" ADD CONSTRAINT FK_HEATHMONITORINGNOTE_STAFF
	FOREIGN KEY (STAFFID) REFERENCES "STAFF"(STAFFID)
	ON DELETE CASCADE;	
	
-- ForeignKey [FK_HIC_RELATIONS_PATIENT] --
ALTER TABLE "HIC" ADD CONSTRAINT FK_HIC_PATIENT
	FOREIGN KEY (PATIENTID) REFERENCES "PATIENT"(PATIENTID)
	ON DELETE CASCADE;	

-- ForeignKey [FK_HOSPITALIZATIONCERTIFICATE_RELATIONS_PATIENT] --
ALTER TABLE "HOSPITALIZATIONCERTIFICATE" ADD CONSTRAINT FK_HOSPITALIZATIONCERTIFICATE_PATIENT
	FOREIGN KEY (PATIENTID) REFERENCES "PATIENT"(PATIENTID)
	ON DELETE CASCADE;	
	
-- ForeignKey [FK_HOSPITALIZATIONCERTIFICATE_RELATIONS_STAFF] --
ALTER TABLE "HOSPITALIZATIONCERTIFICATE" ADD CONSTRAINT FK_HOSPITALIZATIONCERTIFICATE_STAFF
	FOREIGN KEY (STAFFID) REFERENCES "STAFF"(STAFFID)
	ON DELETE CASCADE;	
	
-- ForeignKey [FK_MEDICINEBILLDETAIL_RELATIONS_BILL] --
ALTER TABLE "MEDICINEBILLDETAIL" ADD CONSTRAINT FK_MEDICINEBILLDETAIL_BILL
	FOREIGN KEY (BILLID) REFERENCES "BILL"(BILLID)
	ON DELETE CASCADE;
	
-- ForeignKey [FK_MEDICINEBILLDETAIL_RELATIONS_MEDICINE] --
ALTER TABLE "MEDICINEBILLDETAIL" ADD CONSTRAINT FK_MEDICINEBILLDETAIL_MEDICINE
	FOREIGN KEY (MEDICINEID) REFERENCES "MEDICINE"(MEDICINEID)
	ON DELETE CASCADE;	
	
-- ForeignKey [FK_PRESCRIPTION_RELATIONS_PATIENT] --
ALTER TABLE "PRESCRIPTION" ADD CONSTRAINT FK_PRESCRIPTION_PATIENT
	FOREIGN KEY (PATIENTID) REFERENCES "PATIENT"(PATIENTID)
	ON DELETE CASCADE;		
	
-- ForeignKey [FK_PRESCRIPTION_RELATIONS_STAFF] --
ALTER TABLE "PRESCRIPTION" ADD CONSTRAINT FK_PRESCRIPTION_STAFF
	FOREIGN KEY (STAFFID) REFERENCES "STAFF"(STAFFID)
	ON DELETE CASCADE;		

-- ForeignKey [FK_PRESCRIPTIONDETAIL_RELATIONS_PRESCRIPTION] --
ALTER TABLE "PRESCRIPTIONDETAIL" ADD CONSTRAINT FK_PRESCRIPTIONDETAIL_PRESCRIPTION
	FOREIGN KEY (PRESCRIPTIONID) REFERENCES "PRESCRIPTION"(PRESCRIPTIONID)
	ON DELETE CASCADE;	

-- ForeignKey [FK_RENTMATERIALBILLDETAIL_RELATIONS_BILL] --
ALTER TABLE "RENTMATERIALBILLDETAIL" ADD CONSTRAINT FK_RENTMATERIALBILLDETAIL_BILL
	FOREIGN KEY (BILLID) REFERENCES "BILL"(BILLID)
	ON DELETE CASCADE;	

-- ForeignKey [FK_RENTMATERIALBILLDETAIL_RELATIONS_MATERIAL] --
ALTER TABLE "RENTMATERIALBILLDETAIL" ADD CONSTRAINT FK_RENTMATERIALBILLDETAIL_MATERIAL
	FOREIGN KEY (MATERIALID) REFERENCES "MATERIAL"(MATERIALID)
	ON DELETE CASCADE;	

-- ForeignKey [FK_ROLEDETAIL_RELATIONS_ROLE] --
ALTER TABLE "ROLEDETAIL" ADD CONSTRAINT FK_ROLEDETAIL_ROLE
	FOREIGN KEY (ROLEID) REFERENCES "ROLE"(ROLEID)
	ON DELETE CASCADE;
	
-- ForeignKey [FK_ROLEDETAIL_RELATIONS_ROLEFUNCTION] --
ALTER TABLE "ROLEDETAIL" ADD CONSTRAINT FK_ROLEDETAIL_ROLEFUNCTION
	FOREIGN KEY (FUNCTIONID) REFERENCES "ROLEFUNCTION"(FUNCTIONID)
	ON DELETE CASCADE;	
	
-- ForeignKey [FK_SERVICEBILLDETAIL_RELATIONS_BILL] --
ALTER TABLE "SERVICEBILLDETAIL" ADD CONSTRAINT FK_SERVICEBILLDETAIL_BILL
	FOREIGN KEY (BILLID) REFERENCES "BILL"(BILLID)
	ON DELETE CASCADE;		
	
-- ForeignKey [FK_SERVICEBILLDETAIL_RELATIONS_SERVICE] --
ALTER TABLE "SERVICEBILLDETAIL" ADD CONSTRAINT FK_SERVICEBILLDETAIL_SERVICE
	FOREIGN KEY (SERVICEID) REFERENCES "SERVICE"(SERVICEID)
	ON DELETE CASCADE;
	
-- ForeignKey [FK_STAFF_RELATIONS_DEPARTMENT] --
ALTER TABLE "STAFF" ADD CONSTRAINT FK_STAFF_DEPARTMENT
	FOREIGN KEY (DEPARTMENTID) REFERENCES "DEPARTMENT"(DEPARTMENTID)
	ON DELETE CASCADE;

-- ForeignKey [FK_STAFF_RELATIONS_MAJOR] --
ALTER TABLE "STAFF" ADD CONSTRAINT FK_STAFF_MAJOR
	FOREIGN KEY (MAJORID) REFERENCES "MAJOR"(MAJORID)
	ON DELETE CASCADE;
	
-- ForeignKey [FK_STAFF_RELATIONS_MAJOR] --
ALTER TABLE "STAFF" ADD CONSTRAINT FK_STAFF_ROLE
	FOREIGN KEY (ROLEID) REFERENCES "ROLE"(ROLEID)
	ON DELETE CASCADE;

-- ForeignKey [FK_SURGICAL_RELATIONS_PATIENT] --
ALTER TABLE "SURGICAL" ADD CONSTRAINT FK_SURGICAL_PATIENT
	FOREIGN KEY (PATIENTID) REFERENCES "PATIENT"(PATIENTID)
	ON DELETE CASCADE;

-- ForeignKey [FK_SURGICALDETAIL_RELATIONS_STAFF] --
ALTER TABLE "SURGICALDETAIL" ADD CONSTRAINT FK_SURGICALDETAIL_STAFF
	FOREIGN KEY (STAFFID) REFERENCES "STAFF"(STAFFID)
	ON DELETE CASCADE;

-- ForeignKey [FK_SURGICALDETAIL_RELATIONS_SURGICAL] --
ALTER TABLE "SURGICALDETAIL" ADD CONSTRAINT FK_SURGICALDETAIL_SURGICAL
	FOREIGN KEY (SURGICALID) REFERENCES "SURGICAL"(SURGICALID)
	ON DELETE CASCADE;

-- ForeignKey [FK_TESTCERTIFICATE_RELATIONS_PATIENT] --
ALTER TABLE "TESTCERTIFICATE" ADD CONSTRAINT FK_TESTCERTIFICATE_PATIENT
	FOREIGN KEY (PATIENTID) REFERENCES "PATIENT"(PATIENTID)
	ON DELETE CASCADE;

-- ForeignKey [FK_TESTCERTIFICATE_RELATIONS_STAFF] --
ALTER TABLE "TESTCERTIFICATE" ADD CONSTRAINT FK_TESTCERTIFICATE_STAFF
	FOREIGN KEY (STAFFID) REFERENCES "STAFF"(STAFFID)
	ON DELETE CASCADE;

-- ForeignKey [FK_TESTDETAIL_RELATIONS_TESTCERTIFICATE] --
ALTER TABLE "TESTDETAIL" ADD CONSTRAINT FK_TESTDETAIL_TESTCERTIFICATE
	FOREIGN KEY (TCID) REFERENCES "TESTCERTIFICATE"(TCID)
	ON DELETE CASCADE;
	
-- ForeignKey [FK_TESTDETAIL_RELATIONS_TESTTYPE] --
ALTER TABLE "TESTDETAIL" ADD CONSTRAINT FK_TESTDETAIL_TESTTYPE
	FOREIGN KEY (TESTTYPEID) REFERENCES "TESTTYPE"(TESTTYPEID)
	ON DELETE CASCADE;


