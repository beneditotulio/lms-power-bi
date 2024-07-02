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
('CTR0000', '', 'COUNTRY', 'N/A', ' ', 0, ' '),
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


/*
begin region
20/10/2023
Created by IP
*/

-- Inserir idiomas na tabela GeneralData
INSERT INTO GeneralData ([ID], [ParentId], [ClassifierType], [Description], [ShortName], [IsDefault], [ExtCode])
VALUES
    ('IDM0000', ' ', 'IDIOMA', 'N/A', ' ', 0, ' '),
    ('IDM0001', ' ', 'IDIOMA', 'Inglês', ' ', 0, ' '),
    ('IDM0002', ' ', 'IDIOMA', 'Espanhol', ' ', 0, ' '),
    ('IDM0003', ' ', 'IDIOMA', 'Francês', ' ', 0, ' '),
    ('IDM0004', ' ', 'IDIOMA', 'Alemão', ' ', 0, ' '),
    ('IDM0005', ' ', 'IDIOMA', 'Italiano', ' ', 0, ' '),
    ('IDM0006', ' ', 'IDIOMA', 'Português', ' ', 0, ' '),
    ('IDM0007', ' ', 'IDIOMA', 'Holandês', ' ', 0, ' '),
    ('IDM0008', ' ', 'IDIOMA', 'Sueco', ' ', 0, ' '),
    ('IDM0009', ' ', 'IDIOMA', 'Norueguês', ' ', 0, ' '),
    ('IDM0010', ' ', 'IDIOMA', 'Dinamarquês', ' ', 0, ' '),
    ('IDM0011', ' ', 'IDIOMA', 'Islandês', ' ', 0, ' '),
    ('IDM0012', ' ', 'IDIOMA', 'Finlandês', ' ', 0, ' '),
    ('IDM0013', ' ', 'IDIOMA', 'Grego', ' ', 0, ' '),
    ('IDM0014', ' ', 'IDIOMA', 'Turco', ' ', 0, ' '),
    ('IDM0015', ' ', 'IDIOMA', 'Árabe', ' ', 0, ' '),
    ('IDM0016', ' ', 'IDIOMA', 'Hebraico', ' ', 0, ' '),
    ('IDM0017', ' ', 'IDIOMA', 'Russo', ' ', 0, ' '),
    ('IDM0018', ' ', 'IDIOMA', 'Ucraniano', ' ', 0, ' '),
    ('IDM0019', ' ', 'IDIOMA', 'Polonês', ' ', 0, ' '),
    ('IDM0020', ' ', 'IDIOMA', 'Tcheco', ' ', 0, ' '),
    ('IDM0021', ' ', 'IDIOMA', 'Húngaro', ' ', 0, ' '),
    ('IDM0022', ' ', 'IDIOMA', 'Romeno', ' ', 0, ' '),
    ('IDM0023', ' ', 'IDIOMA', 'Búlgaro', ' ', 0, ' '),
    ('IDM0024', ' ', 'IDIOMA', 'Sérvio', ' ', 0, ' '),
    ('IDM0025', ' ', 'IDIOMA', 'Croata', ' ', 0, ' '),
    ('IDM0026', ' ', 'IDIOMA', 'Esloveno', ' ', 0, ' '),
    ('IDM0027', ' ', 'IDIOMA', 'Macedônio', ' ', 0, ' '),
    ('IDM0028', ' ', 'IDIOMA', 'Albanês', ' ', 0, ' '),
    ('IDM0029', ' ', 'IDIOMA', 'Lituano', ' ', 0, ' '),
    ('IDM0030', ' ', 'IDIOMA', 'Letão', ' ', 0, ' '),
    ('IDM0031', ' ', 'IDIOMA', 'Estoniano', ' ', 0, ' '),
    ('IDM0032', ' ', 'IDIOMA', 'Chinês (simplificado)', ' ', 0, ' '),
    ('IDM0033', ' ', 'IDIOMA', 'Chinês (tradicional)', ' ', 0, ' '),
    ('IDM0034', ' ', 'IDIOMA', 'Japonês', ' ', 0, ' '),
    ('IDM0035', ' ', 'IDIOMA', 'Coreano', ' ', 0, ' '),
    ('IDM0036', ' ', 'IDIOMA', 'Vietnamita', ' ', 0, ' '),
    ('IDM0037', ' ', 'IDIOMA', 'Tailandês', ' ', 0, ' '),
    ('IDM0038', ' ', 'IDIOMA', 'Malaio', ' ', 0, ' '),
    ('IDM0039', ' ', 'IDIOMA', 'Indonésio', ' ', 0, ' '),
    ('IDM0040', ' ', 'IDIOMA', 'Hindi', ' ', 0, ' '),
    ('IDM0041', ' ', 'IDIOMA', 'Bengali', ' ', 0, ' '),
    ('IDM0042', ' ', 'IDIOMA', 'Punjabi', ' ', 0, ' '),
    ('IDM0043', ' ', 'IDIOMA', 'Marathi', ' ', 0, ' '),
    ('IDM0044', ' ', 'IDIOMA', 'Tamil', ' ', 0, ' '),
    ('IDM0045', ' ', 'IDIOMA', 'Telugu', ' ', 0, ' '),
    ('IDM0046', ' ', 'IDIOMA', 'Kannada', ' ', 0, ' '),
    ('IDM0047', ' ', 'IDIOMA', 'Urdu', ' ', 0, ' '),
    ('IDM0048', ' ', 'IDIOMA', 'Áfrikaans', ' ', 0, ' '),
    ('IDM0049', ' ', 'IDIOMA', 'Swahili', ' ', 0, ' '),
    ('IDM0050', ' ', 'IDIOMA', 'Zulu', ' ', 0, ' '),
    ('IDM0051', ' ', 'IDIOMA', 'Xhosa', ' ', 0, ' '),
    ('IDM0052', ' ', 'IDIOMA', 'Somali', ' ', 0, ' '),
    ('IDM0053', ' ', 'IDIOMA', 'Amárico', ' ', 0, ' '),
    ('IDM0054', ' ', 'IDIOMA', 'Tigrínia', ' ', 0, ' '),
    ('IDM0055', ' ', 'IDIOMA', 'Oromo', ' ', 0, ' '),
    ('IDM0056', ' ', 'IDIOMA', 'Afegão', ' ', 0, ' '),
    ('IDM0057', ' ', 'IDIOMA', 'Persa', ' ', 0, ' '),
    ('IDM0058', ' ', 'IDIOMA', 'Curdo', ' ', 0, ' '),
    ('IDM0059', ' ', 'IDIOMA', 'Turcomeno', ' ', 0, ' '),
    ('IDM0060', ' ', 'IDIOMA', 'Quirguiz', ' ', 0, ' '),
    ('IDM0061', ' ', 'IDIOMA', 'Cazaque', ' ', 0, ' '),
    ('IDM0062', ' ', 'IDIOMA', 'Uzbeque', ' ', 0, ' '),
    ('IDM0063', ' ', 'IDIOMA', 'Tadjique', ' ', 0, ' '),
    ('IDM0064', ' ', 'IDIOMA', 'Quirguiz', ' ', 0, ' '),
    ('IDM0065', ' ', 'IDIOMA', 'Cazaque', ' ', 0, ' '),
    ('IDM0066', ' ', 'IDIOMA', 'Uzbeque', ' ', 0, ' '),
    ('IDM0067', ' ', 'IDIOMA', 'Tadjique', ' ', 0, ' '),
    ('IDM0068', ' ', 'IDIOMA', 'Hindi', ' ', 0, ' '),
    ('IDM0069', ' ', 'IDIOMA', 'Punjabi', ' ', 0, ' '),
    ('IDM0070', ' ', 'IDIOMA', 'Gujarati', ' ', 0, ' '),
    ('IDM0071', ' ', 'IDIOMA', 'Bengali', ' ', 0, ' '),
    ('IDM0072', ' ', 'IDIOMA', 'Oriya', ' ', 0, ' '),
    ('IDM0073', ' ', 'IDIOMA', 'Assamês', ' ', 0, ' '),
    ('IDM0074', ' ', 'IDIOMA', 'Cingalês', ' ', 0, ' '),
    ('IDM0075', ' ', 'IDIOMA', 'Nepalês', ' ', 0, ' '),
    ('IDM0076', ' ', 'IDIOMA', 'Tibetano', ' ', 0, ' '),
    ('IDM0077', ' ', 'IDIOMA', 'Birmânes', ' ', 0, ' '),
    ('IDM0078', ' ', 'IDIOMA', 'Laosiano', ' ', 0, ' '),
    ('IDM0079', ' ', 'IDIOMA', 'Cambojano', ' ', 0, ' '),
    ('IDM0080', ' ', 'IDIOMA', 'Tailandês', ' ', 0, ' '),
    ('IDM0081', ' ', 'IDIOMA', 'Lao', ' ', 0, ' '),
    ('IDM0082', ' ', 'IDIOMA', 'Khmer', ' ', 0, ' '),
    ('IDM0083', ' ', 'IDIOMA', 'Malaiala', ' ', 0, ' '),
    ('IDM0084', ' ', 'IDIOMA', 'Cingalês', ' ', 0, ' '),
    ('IDM0085', ' ', 'IDIOMA', 'Nepalês', ' ', 0, ' '),
    ('IDM0086', ' ', 'IDIOMA', 'Tibetano', ' ', 0, ' '),
    ('IDM0087', ' ', 'IDIOMA', 'Birmânes', ' ', 0, ' '),
    ('IDM0088', ' ', 'IDIOMA', 'Laosiano', ' ', 0, ' '),
    ('IDM0089', ' ', 'IDIOMA', 'Cambojano', ' ', 0, ' '),
    ('IDM0090', ' ', 'IDIOMA', 'Tailandês', ' ', 0, ' '),
    ('IDM0091', ' ', 'IDIOMA', 'Malaio', ' ', 0, ' '),
    ('IDM0092', ' ', 'IDIOMA', 'Indonésio', ' ', 0, ' '),
    ('IDM0093', ' ', 'IDIOMA', 'Filipino', ' ', 0, ' '),
    ('IDM0094', ' ', 'IDIOMA', 'Tagalog', ' ', 0, ' '),
    ('IDM0095', ' ', 'IDIOMA', 'Guarani', ' ', 0, ' '),
    ('IDM0096', ' ', 'IDIOMA', 'Quechua', ' ', 0, ' '),
    ('IDM0097', ' ', 'IDIOMA', 'Nahuatl', ' ', 0, ' '),
    ('IDM0098', ' ', 'IDIOMA', 'Maori', ' ', 0, ' '),
    ('IDM0099', ' ', 'IDIOMA', 'Samoano', ' ', 0, ' '),
    ('IDM0100', ' ', 'IDIOMA', 'Havaiano', ' ', 0, ' ');
GO

-- Inserir mais 50 idiomas na tabela GeneralData
INSERT INTO GeneralData ([ID], [ParentId], [ClassifierType], [Description], [ShortName], [IsDefault], [ExtCode])
VALUES
    ('IDM0101', ' ', 'IDIOMA', 'Sânscrito', ' ', 0, ' '),
    ('IDM0102', ' ', 'IDIOMA', 'Suaíli', ' ', 0, ' '),
    ('IDM0103', ' ', 'IDIOMA', 'Hausa', ' ', 0, ' '),
    ('IDM0104', ' ', 'IDIOMA', 'Iorubá', ' ', 0, ' '),
    ('IDM0105', ' ', 'IDIOMA', 'Xhosa', ' ', 0, ' '),
    ('IDM0106', ' ', 'IDIOMA', 'Maori', ' ', 0, ' '),
    ('IDM0107', ' ', 'IDIOMA', 'Esperanto', ' ', 0, ' '),
    ('IDM0108', ' ', 'IDIOMA', 'Eslovaco', ' ', 0, ' '),
    ('IDM0109', ' ', 'IDIOMA', 'Letão', ' ', 0, ' '),
    ('IDM0110', ' ', 'IDIOMA', 'Georgiano', ' ', 0, ' '),
    ('IDM0111', ' ', 'IDIOMA', 'Armênio', ' ', 0, ' '),
    ('IDM0112', ' ', 'IDIOMA', 'Azerbaijani', ' ', 0, ' '),
    ('IDM0113', ' ', 'IDIOMA', 'Cazaque', ' ', 0, ' '),
    ('IDM0114', ' ', 'IDIOMA', 'Turcomeno', ' ', 0, ' '),
    ('IDM0115', ' ', 'IDIOMA', 'Curdo', ' ', 0, ' '),
    ('IDM0116', ' ', 'IDIOMA', 'Pashto', ' ', 0, ' '),
    ('IDM0117', ' ', 'IDIOMA', 'Urdu', ' ', 0, ' '),
    ('IDM0118', ' ', 'IDIOMA', 'Nepali', ' ', 0, ' '),
    ('IDM0119', ' ', 'IDIOMA', 'Sinhala', ' ', 0, ' '),
    ('IDM0120', ' ', 'IDIOMA', 'Khmer', ' ', 0, ' '),
    ('IDM0121', ' ', 'IDIOMA', 'Bengali', ' ', 0, ' '),
    ('IDM0122', ' ', 'IDIOMA', 'Telugu', ' ', 0, ' '),
    ('IDM0123', ' ', 'IDIOMA', 'Tamil', ' ', 0, ' '),
    ('IDM0124', ' ', 'IDIOMA', 'Marathi', ' ', 0, ' '),
    ('IDM0125', ' ', 'IDIOMA', 'Gujarati', ' ', 0, ' '),
    ('IDM0126', ' ', 'IDIOMA', 'Punjabi', ' ', 0, ' '),
    ('IDM0127', ' ', 'IDIOMA', 'Hindi', ' ', 0, ' '),
    ('IDM0128', ' ', 'IDIOMA', 'Urdu', ' ', 0, ' '),
    ('IDM0129', ' ', 'IDIOMA', 'Malayalam', ' ', 0, ' '),
    ('IDM0130', ' ', 'IDIOMA', 'Tulu', ' ', 0, ' '),
    ('IDM0131', ' ', 'IDIOMA', 'Kannada', ' ', 0, ' '),
    ('IDM0132', ' ', 'IDIOMA', 'Oriya', ' ', 0, ' '),
    ('IDM0133', ' ', 'IDIOMA', 'Assamese', ' ', 0, ' '),
    ('IDM0134', ' ', 'IDIOMA', 'Kashmiri', ' ', 0, ' '),
    ('IDM0135', ' ', 'IDIOMA', 'Sindhi', ' ', 0, ' '),
    ('IDM0136', ' ', 'IDIOMA', 'Nepali', ' ', 0, ' '),
    ('IDM0137', ' ', 'IDIOMA', 'Bodo', ' ', 0, ' '),
    ('IDM0138', ' ', 'IDIOMA', 'Manipuri', ' ', 0, ' '),
    ('IDM0139', ' ', 'IDIOMA', 'Sanskrit', ' ', 0, ' '),
    ('IDM0140', ' ', 'IDIOMA', 'Tibetan', ' ', 0, ' '),
    ('IDM0141', ' ', 'IDIOMA', 'Burmese', ' ', 0, ' '),
    ('IDM0142', ' ', 'IDIOMA', 'Lao', ' ', 0, ' '),
    ('IDM0143', ' ', 'IDIOMA', 'Khmer', ' ', 0, ' '),
    ('IDM0144', ' ', 'IDIOMA', 'Vietnamese', ' ', 0, ' '),
    ('IDM0145', ' ', 'IDIOMA', 'Hmong', ' ', 0, ' '),
    ('IDM0146', ' ', 'IDIOMA', 'Igbo', ' ', 0, ' '),
    ('IDM0147', ' ', 'IDIOMA', 'Yoruba', ' ', 0, ' '),
    ('IDM0148', ' ', 'IDIOMA', 'Zulu', ' ', 0, ' '),
    ('IDM0149', ' ', 'IDIOMA', 'Somali', ' ', 0, ' '),
    ('IDM0150', ' ', 'IDIOMA', 'Amharic', ' ', 0, ' ');
GO


-- Inserir 50 categorias de livros na tabela GeneralData
INSERT INTO GeneralData ([ID], [ParentId], [ClassifierType], [Description], [ShortName], [IsDefault], [ExtCode])
VALUES
    ('CAT0000', ' ', 'CATEGORIA', 'N/A', ' ', 0, ' '),
    ('CAT0001', ' ', 'CATEGORIA', 'Ficção Científica', ' ', 0, ' '),
    ('CAT0002', ' ', 'CATEGORIA', 'Fantasia', ' ', 0, ' '),
    ('CAT0003', ' ', 'CATEGORIA', 'Romance', ' ', 0, ' '),
    ('CAT0004', ' ', 'CATEGORIA', 'Mistério', ' ', 0, ' '),
    ('CAT0005', ' ', 'CATEGORIA', 'Suspense', ' ', 0, ' '),
    ('CAT0006', ' ', 'CATEGORIA', 'Aventura', ' ', 0, ' '),
    ('CAT0007', ' ', 'CATEGORIA', 'História', ' ', 0, ' '),
    ('CAT0008', ' ', 'CATEGORIA', 'Biografia', ' ', 0, ' '),
    ('CAT0009', ' ', 'CATEGORIA', 'Política', ' ', 0, ' '),
    ('CAT0010', ' ', 'CATEGORIA', 'Autoajuda', ' ', 0, ' '),
    ('CAT0011', ' ', 'CATEGORIA', 'Ficção Histórica', ' ', 0, ' '),
    ('CAT0012', ' ', 'CATEGORIA', 'Literatura Clássica', ' ', 0, ' '),
    ('CAT0013', ' ', 'CATEGORIA', 'Poesia', ' ', 0, ' '),
    ('CAT0014', ' ', 'CATEGORIA', 'Humor', ' ', 0, ' '),
    ('CAT0015', ' ', 'CATEGORIA', 'Ciência', ' ', 0, ' '),
    ('CAT0016', ' ', 'CATEGORIA', 'Tecnologia', ' ', 0, ' '),
    ('CAT0017', ' ', 'CATEGORIA', 'Psicologia', ' ', 0, ' '),
    ('CAT0018', ' ', 'CATEGORIA', 'Filosofia', ' ', 0, ' '),
    ('CAT0019', ' ', 'CATEGORIA', 'Religião', ' ', 0, ' '),
    ('CAT0020', ' ', 'CATEGORIA', 'Arte', ' ', 0, ' '),
    ('CAT0021', ' ', 'CATEGORIA', 'Música', ' ', 0, ' '),
    ('CAT0022', ' ', 'CATEGORIA', 'Esportes', ' ', 0, ' '),
    ('CAT0023', ' ', 'CATEGORIA', 'Viagem', ' ', 0, ' '),
    ('CAT0024', ' ', 'CATEGORIA', 'Culinária', ' ', 0, ' '),
    ('CAT0025', ' ', 'CATEGORIA', 'Quadrinhos', ' ', 0, ' '),
    ('CAT0026', ' ', 'CATEGORIA', 'Literatura Infantil', ' ', 0, ' '),
    ('CAT0027', ' ', 'CATEGORIA', 'Literatura Juvenil', ' ', 0, ' '),
    ('CAT0028', ' ', 'CATEGORIA', 'História em Quadrinhos', ' ', 0, ' '),
    ('CAT0029', ' ', 'CATEGORIA', 'Drama', ' ', 0, ' '),
    ('CAT0030', ' ', 'CATEGORIA', 'Teatro', ' ', 0, ' '),
    ('CAT0031', ' ', 'CATEGORIA', 'Clube do Livro', ' ', 0, ' '),
    ('CAT0032', ' ', 'CATEGORIA', 'Ação', ' ', 0, ' '),
    ('CAT0033', ' ', 'CATEGORIA', 'Horror', ' ', 0, ' '),
    ('CAT0034', ' ', 'CATEGORIA', 'Ficção Fantástica', ' ', 0, ' '),
    ('CAT0035', ' ', 'CATEGORIA', 'Ciência-Ficção Apocalíptica', ' ', 0, ' '),
    ('CAT0036', ' ', 'CATEGORIA', 'História Alternativa', ' ', 0, ' '),
    ('CAT0037', ' ', 'CATEGORIA', 'Ficção Científica Espacial', ' ', 0, ' '),
    ('CAT0038', ' ', 'CATEGORIA', 'Ficção Científica Distópica', ' ', 0, ' '),
    ('CAT0039', ' ', 'CATEGORIA', 'Romance de Época', ' ', 0, ' '),
    ('CAT0040', ' ', 'CATEGORIA', 'Romance Contemporâneo', ' ', 0, ' '),
    ('CAT0041', ' ', 'CATEGORIA', 'Romance Histórico', ' ', 0, ' '),
    ('CAT0042', ' ', 'CATEGORIA', 'Romance Paranormal', ' ', 0, ' '),
    ('CAT0043', ' ', 'CATEGORIA', 'Romance Erótico', ' ', 0, ' '),
    ('CAT0044', ' ', 'CATEGORIA', 'Romance LGBT', ' ', 0, ' '),
    ('CAT0045', ' ', 'CATEGORIA', 'Ficção de Espionagem', ' ', 0, ' '),
    ('CAT0046', ' ', 'CATEGORIA', 'Mistério Criminal', ' ', 0, ' '),
    ('CAT0047', ' ', 'CATEGORIA', 'Mistério de Detetive', ' ', 0, ' '),
    ('CAT0048', ' ', 'CATEGORIA', 'Mistério de Crime Real', ' ', 0, ' '),
    ('CAT0049', ' ', 'CATEGORIA', 'Thriller de Espionagem', ' ', 0, ' '),
    ('CAT0050', ' ', 'CATEGORIA', 'Thriller Psicológico', ' ', 0, ' ');
    GO


-- Inserir 50 CDUs na tabela GeneralData
INSERT INTO GeneralData ([ID], [ParentId], [ClassifierType], [Description], [ShortName], [IsDefault], [ExtCode])
VALUES
    ('CDU0000', ' ', 'CDU', '000 - N/A', ' ', 0, ' '),
    ('CDU0001', ' ', 'CDU', '001 - Conhecimento geral', ' ', 0, ' '),
    ('CDU0002', ' ', 'CDU', '002 - Biblioteconomia, documentação', ' ', 0, ' '),
    ('CDU0003', ' ', 'CDU', '003 - Sistemas', ' ', 0, ' '),
    ('CDU0004', ' ', 'CDU', '004 - Ciência e conhecimento', ' ', 0, ' '),
    ('CDU0005', ' ', 'CDU', '005 - Matemática e ciências naturais', ' ', 0, ' '),
    ('CDU0006', ' ', 'CDU', '006 - Ciências aplicadas', ' ', 0, ' '),
    ('CDU0007', ' ', 'CDU', '007 - Arte, arquitetura', ' ', 0, ' '),
    ('CDU0008', ' ', 'CDU', '008 - Língua, linguística, filologia', ' ', 0, ' '),
    ('CDU0009', ' ', 'CDU', '009 - Geografia, biografia, história', ' ', 0, ' '),
    ('CDU0010', ' ', 'CDU', '010 - Documentação e publicações', ' ', 0, ' '),
    ('CDU0011', ' ', 'CDU', '011 - Bibliotecas e ciência da informação', ' ', 0, ' '),
    ('CDU0012', ' ', 'CDU', '012 - Padrões de informação', ' ', 0, ' '),
    ('CDU0013', ' ', 'CDU', '013 - Registo', ' ', 0, ' '),
    ('CDU0014', ' ', 'CDU', '014 - Publicações em série', ' ', 0, ' '),
    ('CDU0015', ' ', 'CDU', '015 - Publicações eletrônicas', ' ', 0, ' '),
    ('CDU0016', ' ', 'CDU', '016 - Organização e informação da documentação', ' ', 0, ' '),
    ('CDU0017', ' ', 'CDU', '017 - Documentação, publicações em série', ' ', 0, ' '),
    ('CDU0018', ' ', 'CDU', '018 - Documentação audiovisual', ' ', 0, ' '),
    ('CDU0019', ' ', 'CDU', '019 - Documentação tipográfica', ' ', 0, ' '),
    ('CDU0020', ' ', 'CDU', '020 - Bibliotecas e ciência da informação', ' ', 0, ' '),
    ('CDU0021', ' ', 'CDU', '021 - Bibliotecas', ' ', 0, ' '),
    ('CDU0022', ' ', 'CDU', '022 - Arquivos', ' ', 0, ' '),
    ('CDU0023', ' ', 'CDU', '023 - Museus', ' ', 0, ' '),
    ('CDU0024', ' ', 'CDU', '024 - Livros, impressos', ' ', 0, ' '),
    ('CDU0025', ' ', 'CDU', '025 - Bibliografias, catálogos', ' ', 0, ' '),
    ('CDU0026', ' ', 'CDU', '026 - Bibliografia', ' ', 0, ' '),
    ('CDU0027', ' ', 'CDU', '027 - Catálogos', ' ', 0, ' '),
    ('CDU0028', ' ', 'CDU', '028 - Livros raros e manuscritos', ' ', 0, ' '),
    ('CDU0029', ' ', 'CDU', '029 - Publicações governamentais', ' ', 0, ' '),
    ('CDU0030', ' ', 'CDU', '030 - Documentação, publicações em série', ' ', 0, ' '),
    ('CDU0031', ' ', 'CDU', '031 - Documentação audiovisual', ' ', 0, ' '),
    ('CDU0032', ' ', 'CDU', '032 - Documentação tipográfica', ' ', 0, ' '),
    ('CDU0033', ' ', 'CDU', '033 - Processamento da informação', ' ', 0, ' '),
    ('CDU0034', ' ', 'CDU', '034 - Informática', ' ', 0, ' '),
    ('CDU0035', ' ', 'CDU', '035 - Redes de computadores', ' ', 0, ' '),
    ('CDU0036', ' ', 'CDU', '036 - Segurança em informática', ' ', 0, ' '),
    ('CDU0037', ' ', 'CDU', '037 - Software', ' ', 0, ' '),
    ('CDU0038', ' ', 'CDU', '038 - Hardware', ' ', 0, ' '),
    ('CDU0039', ' ', 'CDU', '039 - Electrónica, telecomunicações', ' ', 0, ' '),
    ('CDU0040', ' ', 'CDU', '040 - Ciência e conhecimento', ' ', 0, ' '),
    ('CDU0041', ' ', 'CDU', '041 - Organizações', ' ', 0, ' '),
    ('CDU0042', ' ', 'CDU', '042 - Métodos e técnicas da investigação', ' ', 0, ' '),
    ('CDU0043', ' ', 'CDU', '043 - Literatura', ' ', 0, ' '),
    ('CDU0044', ' ', 'CDU', '044 - Ciências naturais e matemáticas', ' ', 0, ' '),
    ('CDU0045', ' ', 'CDU', '045 - Ciências aplicadas', ' ', 0, ' '),
    ('CDU0046', ' ', 'CDU', '046 - Ciências médicas', ' ', 0, ' '),
    ('CDU0047', ' ', 'CDU', '047 - Ciências agrícolas', ' ', 0, ' '),
    ('CDU0048', ' ', 'CDU', '048 - Ciências florestais', ' ', 0, ' '),
    ('CDU0049', ' ', 'CDU', '049 - Ciências da terra e do espaço', ' ', 0, ' '),
    ('CDU0050', ' ', 'CDU', '050 - Ciências químicas', ' ', 0, ' ');
GO

-- Publishers table
CREATE TABLE Publishers (
    PublisherID INT PRIMARY KEY Identity(1,1),
    PublisherName VARCHAR(100),
    Address VARCHAR(200),
    Phone VARCHAR(15)
);
GO

-- Books table
CREATE TABLE Books (
    ISBN VARCHAR(20) PRIMARY KEY NOT NULL,
    Title VARCHAR(250) NOT NULL,
    Subtitle VARCHAR(250) NOT NULL,
    CDU VARCHAR(20) NOT NULL,
    BookcaseID INT,
    PublisherID INT, -- Foreign key to the Publishers table
    LanguageID  NVARCHAR(50), -- Foreign key to the Languages table
    Pagination INT,
    PublicationYear INT,
    CategoryID NVARCHAR(50),
    AvailableCopies INT,
    CountryID NVARCHAR(50),
    Illustration VARCHAR(250),
    FOREIGN KEY (PublisherID) REFERENCES Publishers(PublisherID),
    FOREIGN KEY (LanguageID) REFERENCES GeneralData(ID),
    FOREIGN KEY (CategoryID) REFERENCES GeneralData(ID),
    FOREIGN KEY (BookcaseID) REFERENCES Bookcases(BookcaseID),
    FOREIGN KEY (CountryID) REFERENCES GeneralData(ID)
);
GO

-- Junction table for relating books to authors (many-to-many)
CREATE TABLE BooksAuthors (
    BookAuthorID INT PRIMARY KEY Identity(1,1),
    ISBN VARCHAR(20),
    AuthorID INT,
    FOREIGN KEY (ISBN) REFERENCES Books(ISBN),
    FOREIGN KEY (AuthorID) REFERENCES Authors(ID)
);
GO


-- Copies table
CREATE TABLE Copies (
    CopyID INT PRIMARY KEY Identity(1,1),
    ISBN VARCHAR(20), -- Foreign key to the Books table
    CopyNumber INT,
    Condition VARCHAR(50),
    FOREIGN KEY (ISBN) REFERENCES Books(ISBN)
);
GO
-- Members table
CREATE TABLE Members (
    MemberID NVARCHAR(50) PRIMARY KEY,
    --MemberName VARCHAR(100),
    FirstName VARCHAR(100),
    OtherName VARCHAR(100),
    LastName VARCHAR(100),
    Gender VARCHAR(10),
    Nationality VARCHAR(50),
    Nuit VARCHAR(20),
    Bi VARCHAR(20),
    MemberType VARCHAR(50),
    Address VARCHAR(200),
    Email VARCHAR(100),
    Phone VARCHAR(15),
    DateCreate DATETIME,
    Status VARCHAR(20),
    UserId NVARCHAR(128)
);
GO
-- Loans table
CREATE TABLE Loans (
    LoanID INT PRIMARY KEY Identity(1,1),
    ISBN VARCHAR(20), -- Foreign key to the Books table
    MemberID INT, -- Foreign key to the Members table
    LoanDate DATE,
    DueDate DATE,
    ReturnedDate DATE,
    FOREIGN KEY (ISBN) REFERENCES Books(ISBN),
    FOREIGN KEY (MemberID) REFERENCES Members(MemberID)
);
GO

-- Loans table
CREATE TABLE Loans (
    LoanID INT PRIMARY KEY Identity(1,1),
    ISBN VARCHAR(20), -- Foreign key to the Books table
    CopyID INT, -- Foreign key to the Books table
    MemberID NVARCHAR(50), -- Foreign key to the Members table
    UserId NVARCHAR(50), -- New foreign key referencing Members(MemberID)
    LoanDate DATE,
    DueDate DATE,
    ReturnedDate DATE,
    FOREIGN KEY (ISBN) REFERENCES Books(ISBN),
    FOREIGN KEY (CopyID) REFERENCES Copies(CopyID),
    FOREIGN KEY (MemberID) REFERENCES Members(MemberID),
    FOREIGN KEY (UserId) REFERENCES Members(MemberID) -- New foreign key constraint
);

-- Reservations table
CREATE TABLE Reservations (
    ReservationID INT PRIMARY KEY,
    ISBN VARCHAR(20), -- Foreign key to the Books table
    MemberID INT, -- Foreign key to the Members table
    ReservationDate DATE,
    FOREIGN KEY (ISBN) REFERENCES Books(ISBN),
    FOREIGN KEY (MemberID) REFERENCES Members(MemberID)
);

-- Fines table
CREATE TABLE Fines (
    FineID INT PRIMARY KEY,
    MemberID INT, -- Foreign key to the Members table
    Amount DECIMAL(10, 2),
    FineDate DATE,
    FOREIGN KEY (MemberID) REFERENCES Members(MemberID)
);

/*
begin region
20/10/2023
Created by IP
*/

/*
begin region
10/01/2024
Created by IP
*/
--Set up Settings table
CREATE TABLE [dbo].[Settings]
(
	[Id] INT NOT NULL PRIMARY KEY Identity(1,1), 
    [InitialFine] NUMERIC(18, 2) NULL, 
    [DailyFine] NUMERIC(18, 2) NULL, 
    [DaysForReturn] INT NULL, 
    [LoanByPerson] INT NULL
)
GO

INSERT INTO [Settings] ([InitialFine], [DailyFine], [DaysForReturn], [LoanByPerson])
            VALUES (10.00, 5.00, 14, 5)
            GO

            SELECT * FROM [Settings]
            GO
/*
end region
10/01/2024
Created by IP
*/

/*
begin region
20/01/2024
Created by IP
*/
--Adding Roles
IF NOT EXISTS (SELECT * FROM AspNetRoles WHERE Name = 'Administrador')
    INSERT INTO AspNetRoles (Id, Name) VALUES ('Adminnistrator', 'Administrador');

IF NOT EXISTS (SELECT * FROM AspNetRoles WHERE Name = 'Bibliotecário')
    INSERT INTO AspNetRoles (Id, Name) VALUES ('Librarian', 'Bibliotecário');

IF NOT EXISTS (SELECT * FROM AspNetRoles WHERE Name = 'Estudante')
    INSERT INTO AspNetRoles (Id, Name) VALUES ('Student', 'Estudante');

IF NOT EXISTS (SELECT * FROM AspNetRoles WHERE Name = 'Catalogador')
    INSERT INTO AspNetRoles (Id, Name) VALUES ('Cataloger', 'Catalogador');

IF NOT EXISTS (SELECT * FROM AspNetRoles WHERE Name = 'Suporte de TI')
    INSERT INTO AspNetRoles (Id, Name) VALUES ('IT Support', 'Suporte de TI');
/*
end region
20/01/2024
Created by IP
*/

/*
begin region
15/02/2024
Created by IP
*/
--FIX Loan CRUD
CREATE TABLE [dbo].[Loans](
	[LoanID] [int] IDENTITY(1,1) NOT NULL,
	[ISBN] [varchar](20) NULL,
	[CopyID] [int] NULL,
	[MemberID] [nvarchar](50) NULL,
	[UserId] [nvarchar](50) NULL,
	[LoanDate] [date] NULL,
	[DueDate] [date] NULL,
	[ReturnedDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[LoanID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Loans]  WITH CHECK ADD FOREIGN KEY([CopyID])
REFERENCES [dbo].[Copies] ([CopyID])
GO

ALTER TABLE [dbo].[Loans]  WITH CHECK ADD FOREIGN KEY([ISBN])
REFERENCES [dbo].[Books] ([ISBN])
GO

ALTER TABLE [dbo].[Loans]  WITH CHECK ADD FOREIGN KEY([MemberID])
REFERENCES [dbo].[Members] ([MemberID])
GO

ALTER TABLE [dbo].[Loans]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[Members] ([MemberID])
GO
/*
end region
15/02/2024
Created by IP
*/

/*
begin region
18/02/2024
Created by IP
*/
--Create Loan History
CREATE TABLE LoanHistory (
    LoanHistoryID INT IDENTITY(1,1) PRIMARY KEY,
    LoanID INT NOT NULL,
    MemberID NVARCHAR(50) NOT NULL,
    Event VARCHAR(50) NOT NULL,
    EventDate DATETIME NOT NULL,
    Details VARCHAR(MAX),
    -- Define foreign key constraints to ensure data integrity
    CONSTRAINT FK_LoanHistory_Loan FOREIGN KEY (LoanID) REFERENCES Loans(LoanID),
    CONSTRAINT FK_LoanHistory_Member FOREIGN KEY (MemberID) REFERENCES Members(MemberID)
);
GO

--Add Loan History
ALTER TABLE Loans
ADD Status NVARCHAR(50) DEFAULT 'Ativo';
GO
/*
end region
18/02/2024
Created by IP
*/

/*
begin region
28/02/2024
Created by IP
*/
--GENERATE POWER BI VIEWS
--1. EMPRÉSTIMOS AO LONGO DO TEMPO
--Empréstimos ao Longo do Tempo: Um gráfico de linhas mostrando a quantidade de empréstimos
--feitos ao longo do tempo, permitindo identificar tendências de aumento ou diminuição no 
--uso da biblioteca.
CREATE VIEW EmpréstimosAoLongoDoTempo AS
SELECT
    LoanDate,
    COUNT(LoanID) AS QuantidadeDeEmpréstimos
FROM
    Loans
WHERE
    LoanDate IS NOT NULL
GROUP BY
    LoanDate
--ORDER BY
--    LoanDate;
GO

--2. LIVROS MAIS EMPRESTADOS
--Livros Mais Emprestados: Um gráfico de barras listando os livros mais emprestados, 
--destacando os títulos mais populares na biblioteca.
CREATE VIEW LivrosMaisEmprestados AS
SELECT
    b.Title,
    COUNT(l.LoanID) AS QuantidadeDeEmpréstimos
FROM
    Loans l
INNER JOIN
    Books b ON l.ISBN = b.ISBN
GROUP BY
    b.Title
--ORDER BY
--    QuantidadeDeEmpréstimos DESC;
GO

--3. ACTIVIDADE DE EMPRÉSTIMO POR CATEGORIA DE LIVRO
--Actividade de Empréstimo por Categoria de Livro: Uma visualização que mostra o número
--de empréstimos por categoria de livro, ajudando a entender quais gêneros são mais populares entre os membros.
CREATE VIEW EmpréstimosPorCategoria AS
SELECT
    gd.Description AS Categoria,
    COUNT(l.LoanID) AS QuantidadeDeEmpréstimos
FROM
    Loans l
INNER JOIN
    Books b ON l.ISBN = b.ISBN
INNER JOIN
    GeneralData gd ON b.CategoryID = gd.ID
GROUP BY
    gd.Description
--ORDER BY
--    QuantidadeDeEmpréstimos DESC;
GO

--4. DISTRIBUIÇÃO DE LIVROS POR EDITORA
--Distribuição de Livros por Editora: Um gráfico de torta ou barra que mostra a quantidade de livros disponíveis
--na biblioteca por editora, oferecendo insights sobre a diversidade do acervo.
CREATE VIEW DistribuicaoLivrosPorEditora AS
SELECT
    p.PublisherName AS Editora,
    COUNT(b.ISBN) AS QuantidadeDeLivros
FROM
    Books b
INNER JOIN
    Publishers p ON b.PublisherID = p.PublisherID
GROUP BY
    p.PublisherName
--ORDER BY
--    QuantidadeDeLivros DESC;
GO

--5. MEMBROS ACTIVOS
--Membros Activos: Uma lista ou tabela dos membros mais ativos com base no número de empréstimos, destacando os usuários mais engajados.
CREATE VIEW MembrosMaisAtivos AS
SELECT
    CONCAT(m.FirstName,' ', m.OtherName,' ', m.LastName) as MemberName,
    COUNT(l.LoanID) AS QuantidadeDeEmpréstimos
FROM
    Loans l
INNER JOIN
    Members m ON l.MemberID = m.MemberID
GROUP BY
    m.FirstName, m.OtherName, m.LastName
--ORDER BY
--    QuantidadeDeEmpréstimos DESC;
GO

--6. STATUS DOS EMPRÉSTIMOS
--Status dos Empréstimos: Um gráfico de barras ou torta que mostra a distribuição do status dos empréstimos (ativo, atrasado, devolvido), 
--ajudando a gerenciar e reduzir atrasos nos empréstimos.
CREATE VIEW StatusDosEmpréstimos AS
SELECT
    Status,
    COUNT(LoanID) AS Quantidade
FROM
    Loans
GROUP BY
    Status
--ORDER BY
--    Quantidade DESC;
GO

--7. ANÁLISE DE MULTAS
--Análise de Multas: Visualização do total de multas acumuladas ao longo do tempo ou análise das multas por membro, 
--para entender melhor o impacto financeiro das políticas de empréstimo.
CREATE VIEW AnaliseDeMultasPorMembro AS
SELECT
    l.MemberID,
    CONCAT(m.FirstName,' ', m.OtherName,' ', m.LastName) as MemberName,
    SUM(CASE 
        WHEN l.ReturnedDate > l.DueDate THEN DATEDIFF(day, l.DueDate, l.ReturnedDate) * ls.DailyFine
        ELSE 0
    END) AS TotalDeMultas
FROM
    Loans l
INNER JOIN
    Members m ON l.MemberID = m.MemberID
INNER JOIN
    LoanSettings ls ON ls.Id = 1 -- Assumindo que existe apenas um conjunto de regras de empréstimo
GROUP BY
    l.MemberID, m.FirstName, m.OtherName, m.LastName
--ORDER BY
--    TotalDeMultas DESC;
GO

--8. LOCALIZAÇÃO DOS LIVROS
--Localização dos Livros: Um mapa ou gráfico detalhado mostrando a localização dos livros dentro da biblioteca, se a informação de localização
--for detalhada o suficiente, ajudando na organização e na localização física dos itens.
CREATE VIEW LocalizacaoDosLivros AS
SELECT
    b.Title,
    b.ISBN,
    bc.BookcaseName,
    bc.Location,
    bc.Description
FROM
    Books b
INNER JOIN
    Bookcases bc ON b.BookcaseID = bc.BookcaseID;
GO

--9. ANÁLISE DE AUTORES
--Análise de Autores: Gráficos mostrando os autores com mais obras na biblioteca ou mais emprestados, destacando os autores favoritos dos membros.
CREATE VIEW AnaliseDeAutores AS
SELECT
    a.AuthorName,
    COUNT(DISTINCT ba.ISBN) AS TotalDeObras,
    COUNT(l.LoanID) AS TotalDeEmpréstimos
FROM
    Authors a
INNER JOIN
    BooksAuthors ba ON a.ID = ba.AuthorID
LEFT JOIN
    Books b ON ba.ISBN = b.ISBN
LEFT JOIN
    Loans l ON b.ISBN = l.ISBN
GROUP BY
    a.AuthorName
--ORDER BY
--    TotalDeEmpréstimos DESC, TotalDeObras DESC;
GO

--10. ANÁLISE DE IDIOMAS DOS LIVROS
--Análise de Idiomas dos Livros: Um gráfico de barras ou torta mostrando a proporção de livros disponíveis em diferentes idiomas, 
--oferecendo uma visão da diversidade linguística do acervo.
CREATE VIEW AnaliseDeIdiomasDosLivros AS
SELECT
    gd.Description AS Idioma,
    COUNT(b.ISBN) AS QuantidadeDeLivros
FROM
    Books b
INNER JOIN
    GeneralData gd ON b.LanguageID = gd.ID
WHERE
    gd.ClassifierType = 'Idioma' -- Supondo que 'ClassifierType' identifica a categoria dos dados em 'GeneralData'
GROUP BY
    gd.Description
--ORDER BY
--    QuantidadeDeLivros DESC;
GO


/*
end region
28/02/2024
Created by IP
*/

/*
begin region
28/03/2024
Created by IP
*/
ALTER TABLE Loans
Alter Column LoanDate datetime
GO

ALTER TABLE Loans
Alter Column DueDate datetime
GO

ALTER TABLE Loans
Alter Column ReturnedDate datetime
GO

--7. ANÁLISE DE MULTAS
--Análise de Multas: Visualização do total de multas acumuladas ao longo do tempo ou análise das multas por membro, 
--para entender melhor o impacto financeiro das políticas de empréstimo.
ALTER VIEW [dbo].[AnaliseDeMultasPorMembro] AS
SELECT
    l.MemberID,
    CONCAT(m.FirstName,' ', m.OtherName,' ', m.LastName) as MemberName,
    SUM(CASE 
        WHEN l.ReturnedDate > l.DueDate THEN DATEDIFF(day, l.DueDate, l.ReturnedDate) * ls.DailyFine
        ELSE 0
    END) AS TotalDeMultas
FROM
    Loans l
INNER JOIN
    Members m ON l.MemberID = m.MemberID
INNER JOIN
    Settings ls ON ls.Id = 1 -- Assumindo que existe apenas um conjunto de regras de empréstimo
GROUP BY
    l.MemberID, m.FirstName, m.OtherName, m.LastName
--ORDER BY
--    TotalDeMultas DESC;
GO
/*
end region
28/03/2024
Created by IP
*/

/*
begin region
02/07/2024
Created by IP
*/
ALTER TABLE Members
    ADD StudentNumber NVARCHAR(MAX); 
GO
/*
end region
02/07/2024
Created by IP
*/