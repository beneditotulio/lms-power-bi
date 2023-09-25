CREATE DATABASE LibraryDB
GO

USE LibraryDB
GO

--DATABASE BACKUP SCRIPT
DECLARE @BackupPath NVARCHAR(255)
DECLARE @BackupFileName NVARCHAR(255)
DECLARE @DateTimeStamp NVARCHAR(50)

-- Define the backup path
SET @BackupPath = 'C:\IP\workspace\'

-- Generate the current date and time as a string (YYYYMMDD_HHMMSS)
SET @DateTimeStamp = REPLACE(CONVERT(NVARCHAR(50), GETDATE(), 120), ':', '')

-- Construct the backup filename with the current date and time
SET @BackupFileName = @BackupPath + 'LibraryDB_' + @DateTimeStamp + '.bak'

-- Backup the database to the dynamically generated filename
BACKUP DATABASE LibraryDB
TO DISK = @BackupFileName
WITH INIT; -- INIT creates a new backup set
GO


/*
begin region
25/09/2023
Created by IP
*/
-- General Data 
CREATE TABLE GeneralData
(
    [ID] [NVARCHAR](50) NOT NULL PRIMARY KEY,
    [ParentId] [NVARCHAR](50) NOT NULL DEFAULT ' ',
    [ClassifierType] [NVARCHAR](50) NOT NULL,
    [Description] [NVARCHAR](255) NOT NULL,
    [ShortName] [NVARCHAR](10) NOT NULL DEFAULT ' ',
    [IsDefault] [INT] NOT NULL DEFAULT 0,
    [ExtCode] [NVARCHAR](50) NOT NULL DEFAULT ' '
);
GO

-- Authors TABLE
CREATE TABLE Authors (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    AuthorName NVARCHAR(255),
    DateOfBirth DATE,
    CountryOfOrigin NVARCHAR(100),
    Biography NVARCHAR(MAX), -- Author's biography
    Website NVARCHAR(255),   -- Author's website URL
    Email NVARCHAR(255),     -- Author's contact email
    Phone NVARCHAR(20)       -- Author's contact phone number
    -- Add any other relevant author information columns here
);
GO

--insert Countries
-- Clear existing data if needed
-- TRUNCATE TABLE GeneralData;

-- Insert statements for 150 countries with Portuguese names
INSERT INTO GeneralData (ID, ParentId, ClassifierType, Description, ShortName, IsDefault, ExtCode)
VALUES
('CTR0001', '', 'COUNTRY', 'Afeganistão', 'AF', 0, 'AF'),
('CTR0002', '', 'COUNTRY', 'Albânia', 'AL', 0, 'AL'),
('CTR0003', '', 'COUNTRY', 'Argélia', 'DZ', 0, 'DZ'),
('CTR0004', '', 'COUNTRY', 'Andorra', 'AD', 0, 'AD'),
('CTR0005', '', 'COUNTRY', 'Angola', 'AO', 0, 'AO'),
('CTR0006', '', 'COUNTRY', 'Antígua e Barbuda', 'AG', 0, 'AG'),
('CTR0007', '', 'COUNTRY', 'Argentina', 'AR', 0, 'AR'),
('CTR0008', '', 'COUNTRY', 'Armênia', 'AM', 0, 'AM'),
('CTR0009', '', 'COUNTRY', 'Austrália', 'AU', 0, 'AU'),
('CTR0010', '', 'COUNTRY', 'Áustria', 'AT', 0, 'AT'),
('CTR0011', '', 'COUNTRY', 'Azerbaijão', 'AZ', 0, 'AZ'),
('CTR0012', '', 'COUNTRY', 'Bahamas', 'BS', 0, 'BS'),
('CTR0013', '', 'COUNTRY', 'Bahrein', 'BH', 0, 'BH'),
('CTR0014', '', 'COUNTRY', 'Bangladesh', 'BD', 0, 'BD'),
('CTR0015', '', 'COUNTRY', 'Barbados', 'BB', 0, 'BB'),
('CTR0016', '', 'COUNTRY', 'Belarus', 'BY', 0, 'BY'),
('CTR0017', '', 'COUNTRY', 'Bélgica', 'BE', 0, 'BE'),
('CTR0018', '', 'COUNTRY', 'Belize', 'BZ', 0, 'BZ'),
('CTR0019', '', 'COUNTRY', 'Benin', 'BJ', 0, 'BJ'),
('CTR0020', '', 'COUNTRY', 'Butão', 'BT', 0, 'BT'),
('CTR0021', '', 'COUNTRY', 'Bolívia', 'BO', 0, 'BO'),
('CTR0022', '', 'COUNTRY', 'Bósnia e Herzegovina', 'BA', 0, 'BA'),
('CTR0023', '', 'COUNTRY', 'Botsuana', 'BW', 0, 'BW'),
('CTR0024', '', 'COUNTRY', 'Brasil', 'BR', 0, 'BR'),
('CTR0025', '', 'COUNTRY', 'Brunei', 'BN', 0, 'BN'),
('CTR0026', '', 'COUNTRY', 'Bulgária', 'BG', 0, 'BG'),
('CTR0027', '', 'COUNTRY', 'Burkina Faso', 'BF', 0, 'BF'),
('CTR0028', '', 'COUNTRY', 'Burundi', 'BI', 0, 'BI'),
('CTR0029', '', 'COUNTRY', 'Cabo Verde', 'CV', 0, 'CV'),
('CTR0030', '', 'COUNTRY', 'Camboja', 'KH', 0, 'KH'),
('CTR0031', '', 'COUNTRY', 'Camarões', 'CM', 0, 'CM'),
('CTR0032', '', 'COUNTRY', 'Canadá', 'CA', 0, 'CA'),
('CTR0033', '', 'COUNTRY', 'República Centro-Africana', 'CF', 0, 'CF'),
('CTR0034', '', 'COUNTRY', 'Chade', 'TD', 0, 'TD'),
('CTR0035', '', 'COUNTRY', 'Chile', 'CL', 0, 'CL'),
('CTR0036', '', 'COUNTRY', 'China', 'CN', 0, 'CN'),
('CTR0037', '', 'COUNTRY', 'Colômbia', 'CO', 0, 'CO'),
('CTR0038', '', 'COUNTRY', 'Comores', 'KM', 0, 'KM'),
('CTR0039', '', 'COUNTRY', 'Congo (Brazavile)', 'CG', 0, 'CG'),
('CTR0040', '', 'COUNTRY', 'Congo (Kinshasa)', 'CD', 0, 'CD'),
('CTR0041', '', 'COUNTRY', 'Costa Rica', 'CR', 0, 'CR'),
('CTR0042', '', 'COUNTRY', 'Croácia', 'HR', 0, 'HR'),
('CTR0043', '', 'COUNTRY', 'Cuba', 'CU', 0, 'CU'),
('CTR0044', '', 'COUNTRY', 'Chipre', 'CY', 0, 'CY'),
('CTR0045', '', 'COUNTRY', 'República Tcheca', 'CZ', 0, 'CZ'),
('CTR0046', '', 'COUNTRY', 'Dinamarca', 'DK', 0, 'DK'),
('CTR0047', '', 'COUNTRY', 'Djibuti', 'DJ', 0, 'DJ'),
('CTR0048', '', 'COUNTRY', 'Dominica', 'DM', 0, 'DM'),
('CTR0049', '', 'COUNTRY', 'República Dominicana', 'DO', 0, 'DO'),
('CTR0050', '', 'COUNTRY', 'Timor-Leste', 'TL', 0, 'TL'),
('CTR0051', '', 'COUNTRY', 'Equador', 'EC', 0, 'EC'),
('CTR0052', '', 'COUNTRY', 'Egito', 'EG', 0, 'EG'),
('CTR0053', '', 'COUNTRY', 'El Salvador', 'SV', 0, 'SV'),
('CTR0054', '', 'COUNTRY', 'Guiné Equatorial', 'GQ', 0, 'GQ'),
('CTR0055', '', 'COUNTRY', 'Eritreia', 'ER', 0, 'ER'),
('CTR0056', '', 'COUNTRY', 'Estônia', 'EE', 0, 'EE'),
('CTR0057', '', 'COUNTRY', 'Eswatini', 'SZ', 0, 'SZ'),
('CTR0058', '', 'COUNTRY', 'Etiópia', 'ET', 0, 'ET'),
('CTR0059', '', 'COUNTRY', 'Fiji', 'FJ', 0, 'FJ'),
('CTR0060', '', 'COUNTRY', 'Finlândia', 'FI', 0, 'FI'),
('CTR0061', '', 'COUNTRY', 'França', 'FR', 0, 'FR'),
('CTR0062', '', 'COUNTRY', 'Gabão', 'GA', 0, 'GA'),
('CTR0063', '', 'COUNTRY', 'Gâmbia', 'GM', 0, 'GM'),
('CTR0064', '', 'COUNTRY', 'Geórgia', 'GE', 0, 'GE'),
('CTR0065', '', 'COUNTRY', 'Alemanha', 'DE', 0, 'DE'),
('CTR0066', '', 'COUNTRY', 'Gana', 'GH', 0, 'GH'),
('CTR0067', '', 'COUNTRY', 'Grécia', 'GR', 0, 'GR'),
('CTR0068', '', 'COUNTRY', 'Granada', 'GD', 0, 'GD'),
('CTR0069', '', 'COUNTRY', 'Guatemala', 'GT', 0, 'GT'),
('CTR0070', '', 'COUNTRY', 'Guiné', 'GN', 0, 'GN'),
('CTR0071', '', 'COUNTRY', 'Guiné-Bissau', 'GW', 0, 'GW'),
('CTR0072', '', 'COUNTRY', 'Guiana', 'GY', 0, 'GY'),
('CTR0073', '', 'COUNTRY', 'Haiti', 'HT', 0, 'HT'),
('CTR0074', '', 'COUNTRY', 'Honduras', 'HN', 0, 'HN'),
('CTR0075', '', 'COUNTRY', 'Hungria', 'HU', 0, 'HU'),
('CTR0076', '', 'COUNTRY', 'Islândia', 'IS', 0, 'IS'),
('CTR0077', '', 'COUNTRY', 'Índia', 'IN', 0, 'IN'),
('CTR0078', '', 'COUNTRY', 'Indonésia', 'ID', 0, 'ID'),
('CTR0079', '', 'COUNTRY', 'Irã', 'IR', 0, 'IR'),
('CTR0080', '', 'COUNTRY', 'Iraque', 'IQ', 0, 'IQ'),
('CTR0081', '', 'COUNTRY', 'Irlanda', 'IE', 0, 'IE'),
('CTR0082', '', 'COUNTRY', 'Israel', 'IL', 0, 'IL'),
('CTR0083', '', 'COUNTRY', 'Itália', 'IT', 0, 'IT'),
('CTR0084', '', 'COUNTRY', 'Costa do Marfim', 'CI', 0, 'CI'),
('CTR0085', '', 'COUNTRY', 'Jamaica', 'JM', 0, 'JM'),
('CTR0086', '', 'COUNTRY', 'Japão', 'JP', 0, 'JP'),
('CTR0087', '', 'COUNTRY', 'Jordânia', 'JO', 0, 'JO'),
('CTR0088', '', 'COUNTRY', 'Cazaquistão', 'KZ', 0, 'KZ'),
('CTR0089', '', 'COUNTRY', 'Quênia', 'KE', 0, 'KE'),
('CTR0090', '', 'COUNTRY', 'Kiribati', 'KI', 0, 'KI'),
('CTR0091', '', 'COUNTRY', 'Kosovo', 'XK', 0, 'XK'),
('CTR0092', '', 'COUNTRY', 'Kuwait', 'KW', 0, 'KW'),
('CTR0093', '', 'COUNTRY', 'Quirguistão', 'KG', 0, 'KG'),
('CTR0094', '', 'COUNTRY', 'Laos', 'LA', 0, 'LA'),
('CTR0095', '', 'COUNTRY', 'Letônia', 'LV', 0, 'LV'),
('CTR0096', '', 'COUNTRY', 'Líbano', 'LB', 0, 'LB'),
('CTR0097', '', 'COUNTRY', 'Lesoto', 'LS', 0, 'LS'),
('CTR0098', '', 'COUNTRY', 'Libéria', 'LR', 0, 'LR'),
('CTR0099', '', 'COUNTRY', 'Líbia', 'LY', 0, 'LY'),
('CTR0100', '', 'COUNTRY', 'Liechtenstein', 'LI', 0, 'LI');
GO

-- Continue with INSERT statements for the remaining countries
INSERT INTO GeneralData (ID, ParentId, ClassifierType, Description, ShortName, IsDefault, ExtCode)
VALUES
('CTR0101', '', 'COUNTRY', 'Lituânia', 'LT', 0, 'LT'),
('CTR0102', '', 'COUNTRY', 'Luxemburgo', 'LU', 0, 'LU'),
('CTR0103', '', 'COUNTRY', 'Macedônia do Norte', 'MK', 0, 'MK'),
('CTR0104', '', 'COUNTRY', 'Madagáscar', 'MG', 0, 'MG'),
('CTR0105', '', 'COUNTRY', 'Malaui', 'MW', 0, 'MW'),
('CTR0106', '', 'COUNTRY', 'Malásia', 'MY', 0, 'MY'),
('CTR0107', '', 'COUNTRY', 'Maldivas', 'MV', 0, 'MV'),
('CTR0108', '', 'COUNTRY', 'Mali', 'ML', 0, 'ML'),
('CTR0109', '', 'COUNTRY', 'Malta', 'MT', 0, 'MT'),
('CTR0110', '', 'COUNTRY', 'Ilhas Marshall', 'MH', 0, 'MH'),
('CTR0111', '', 'COUNTRY', 'Mauritânia', 'MR', 0, 'MR'),
('CTR0112', '', 'COUNTRY', 'Maurícia', 'MU', 0, 'MU'),
('CTR0113', '', 'COUNTRY', 'México', 'MX', 0, 'MX'),
('CTR0114', '', 'COUNTRY', 'Micronésia', 'FM', 0, 'FM'),
('CTR0115', '', 'COUNTRY', 'Moldávia', 'MD', 0, 'MD'),
('CTR0116', '', 'COUNTRY', 'Mônaco', 'MC', 0, 'MC'),
('CTR0117', '', 'COUNTRY', 'Mongólia', 'MN', 0, 'MN'),
('CTR0118', '', 'COUNTRY', 'Montenegro', 'ME', 0, 'ME'),
('CTR0119', '', 'COUNTRY', 'Marrocos', 'MA', 0, 'MA'),
('CTR0120', '', 'COUNTRY', 'Moçambique', 'MZ', 0, 'MZ'),
('CTR0121', '', 'COUNTRY', 'Mianmar (Birmânia)', 'MM', 0, 'MM'),
('CTR0122', '', 'COUNTRY', 'Namíbia', 'NA', 0, 'NA'),
('CTR0123', '', 'COUNTRY', 'Nauru', 'NR', 0, 'NR'),
('CTR0124', '', 'COUNTRY', 'Nepal', 'NP', 0, 'NP'),
('CTR0125', '', 'COUNTRY', 'Países Baixos', 'NL', 0, 'NL'),
('CTR0126', '', 'COUNTRY', 'Nova Zelândia', 'NZ', 0, 'NZ'),
('CTR0127', '', 'COUNTRY', 'Nicarágua', 'NI', 0, 'NI'),
('CTR0128', '', 'COUNTRY', 'Níger', 'NE', 0, 'NE'),
('CTR0129', '', 'COUNTRY', 'Nigéria', 'NG', 0, 'NG'),
('CTR0130', '', 'COUNTRY', 'Coreia do Norte', 'KP', 0, 'KP'),
('CTR0131', '', 'COUNTRY', 'Noruega', 'NO', 0, 'NO'),
('CTR0132', '', 'COUNTRY', 'Omã', 'OM', 0, 'OM'),
('CTR0133', '', 'COUNTRY', 'Paquistão', 'PK', 0, 'PK'),
('CTR0134', '', 'COUNTRY', 'Palau', 'PW', 0, 'PW'),
('CTR0135', '', 'COUNTRY', 'Palestina', 'PS', 0, 'PS'),
('CTR0136', '', 'COUNTRY', 'Panamá', 'PA', 0, 'PA'),
('CTR0137', '', 'COUNTRY', 'Papua-Nova Guiné', 'PG', 0, 'PG'),
('CTR0138', '', 'COUNTRY', 'Paraguai', 'PY', 0, 'PY'),
('CTR0139', '', 'COUNTRY', 'Peru', 'PE', 0, 'PE'),
('CTR0140', '', 'COUNTRY', 'Filipinas', 'PH', 0, 'PH'),
('CTR0141', '', 'COUNTRY', 'Polônia', 'PL', 0, 'PL'),
('CTR0142', '', 'COUNTRY', 'Portugal', 'PT', 0, 'PT'),
('CTR0143', '', 'COUNTRY', 'Catar', 'QA', 0, 'QA'),
('CTR0144', '', 'COUNTRY', 'Romênia', 'RO', 0, 'RO'),
('CTR0145', '', 'COUNTRY', 'Rússia', 'RU', 0, 'RU'),
('CTR0146', '', 'COUNTRY', 'Ruanda', 'RW', 0, 'RW'),
('CTR0147', '', 'COUNTRY', 'São Cristóvão e Névis', 'KN', 0, 'KN'),
('CTR0148', '', 'COUNTRY', 'Santa Lúcia', 'LC', 0, 'LC'),
('CTR0149', '', 'COUNTRY', 'São Vicente e Granadinas', 'VC', 0, 'VC'),
('CTR0150', '', 'COUNTRY', 'Samoa', 'WS', 0, 'WS');
GO

-- Continue with INSERT statements for the remaining countries
INSERT INTO GeneralData (ID, ParentId, ClassifierType, Description, ShortName, IsDefault, ExtCode)
VALUES
('CTR0151', '', 'COUNTRY', 'San Marino', 'SM', 0, 'SM'),
('CTR0152', '', 'COUNTRY', 'São Tomé e Príncipe', 'ST', 0, 'ST'),
('CTR0153', '', 'COUNTRY', 'Arábia Saudita', 'SA', 0, 'SA'),
('CTR0154', '', 'COUNTRY', 'Senegal', 'SN', 0, 'SN'),
('CTR0155', '', 'COUNTRY', 'Sérvia', 'RS', 0, 'RS'),
('CTR0156', '', 'COUNTRY', 'Seicheles', 'SC', 0, 'SC'),
('CTR0157', '', 'COUNTRY', 'Serra Leoa', 'SL', 0, 'SL'),
('CTR0158', '', 'COUNTRY', 'Singapura', 'SG', 0, 'SG'),
('CTR0159', '', 'COUNTRY', 'Eslováquia', 'SK', 0, 'SK'),
('CTR0160', '', 'COUNTRY', 'Eslovênia', 'SI', 0, 'SI'),
('CTR0161', '', 'COUNTRY', 'Ilhas Salomão', 'SB', 0, 'SB'),
('CTR0162', '', 'COUNTRY', 'Somália', 'SO', 0, 'SO'),
('CTR0163', '', 'COUNTRY', 'África do Sul', 'ZA', 0, 'ZA'),
('CTR0164', '', 'COUNTRY', 'Coreia do Sul', 'KR', 0, 'KR'),
('CTR0165', '', 'COUNTRY', 'Sudão do Sul', 'SS', 0, 'SS'),
('CTR0166', '', 'COUNTRY', 'Espanha', 'ES', 0, 'ES'),
('CTR0167', '', 'COUNTRY', 'Sri Lanka', 'LK', 0, 'LK'),
('CTR0168', '', 'COUNTRY', 'Sudão', 'SD', 0, 'SD'),
('CTR0169', '', 'COUNTRY', 'Suriname', 'SR', 0, 'SR'),
('CTR0170', '', 'COUNTRY', 'Suazilândia', 'SZ', 0, 'SZ'),
('CTR0171', '', 'COUNTRY', 'Suécia', 'SE', 0, 'SE'),
('CTR0172', '', 'COUNTRY', 'Suíça', 'CH', 0, 'CH'),
('CTR0173', '', 'COUNTRY', 'Síria', 'SY', 0, 'SY'),
('CTR0174', '', 'COUNTRY', 'Taiwan', 'TW', 0, 'TW'),
('CTR0175', '', 'COUNTRY', 'Tajiquistão', 'TJ', 0, 'TJ'),
('CTR0176', '', 'COUNTRY', 'Tanzânia', 'TZ', 0, 'TZ'),
('CTR0177', '', 'COUNTRY', 'Tailândia', 'TH', 0, 'TH'),
('CTR0178', '', 'COUNTRY', 'Togo', 'TG', 0, 'TG'),
('CTR0179', '', 'COUNTRY', 'Tonga', 'TO', 0, 'TO'),
('CTR0180', '', 'COUNTRY', 'Trindade e Tobago', 'TT', 0, 'TT'),
('CTR0181', '', 'COUNTRY', 'Tunísia', 'TN', 0, 'TN'),
('CTR0182', '', 'COUNTRY', 'Turcomenistão', 'TM', 0, 'TM'),
('CTR0183', '', 'COUNTRY', 'Tuvalu', 'TV', 0, 'TV'),
('CTR0184', '', 'COUNTRY', 'Uganda', 'UG', 0, 'UG'),
('CTR0185', '', 'COUNTRY', 'Ucrânia', 'UA', 0, 'UA'),
('CTR0186', '', 'COUNTRY', 'Emirados Árabes Unidos', 'AE', 0, 'AE'),
('CTR0187', '', 'COUNTRY', 'Reino Unido', 'GB', 0, 'GB'),
('CTR0188', '', 'COUNTRY', 'Estados Unidos', 'US', 0, 'US'),
('CTR0189', '', 'COUNTRY', 'Uruguai', 'UY', 0, 'UY'),
('CTR0190', '', 'COUNTRY', 'Uzbequistão', 'UZ', 0, 'UZ'),
('CTR0191', '', 'COUNTRY', 'Vanuatu', 'VU', 0, 'VU'),
('CTR0192', '', 'COUNTRY', 'Cidade do Vaticano', 'VA', 0, 'VA'),
('CTR0193', '', 'COUNTRY', 'Venezuela', 'VE', 0, 'VE'),
('CTR0194', '', 'COUNTRY', 'Vietnã', 'VN', 0, 'VN'),
('CTR0195', '', 'COUNTRY', 'Iêmen', 'YE', 0, 'YE'),
('CTR0196', '', 'COUNTRY', 'Zâmbia', 'ZM', 0, 'ZM'),
('CTR0197', '', 'COUNTRY', 'Zimbábue', 'ZW', 0, 'ZW'),
('CTR0198', '', 'COUNTRY', 'Outro', 'XX', 0, 'XX'),
('CTR0199', '', 'COUNTRY', 'Desconhecido', 'XX', 0, 'XX'),
('CTR0200', '', 'COUNTRY', 'Global', 'XX', 0, 'XX');
GO

/*
end region
25/09/2023
Created by IP
*/

/*
begin region
26/09/2023
Created by IP
*/

CREATE TABLE Bookcases (
    BookcaseID INT PRIMARY KEY IDENTITY(1,1),
    BookcaseName NVARCHAR(255) NOT NULL,
    Location NVARCHAR(100),
    Capacity INT,
    Description NVARCHAR(255),
    CONSTRAINT Unique_BookcaseName UNIQUE (BookcaseName)
);
GO
/*
end region
26/09/2023
Created by IP
*/