CREATE TABLE BootswatchTheme_Selector
(
	Id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	ThemeName varchar(50) NOT NULL,
	ActiveStatus bit
)
INSERT INTO BootswatchTheme_Selector (ThemeName, ActiveStatus)
VALUES 
('cosmo', 0), 
('yeti', 0), 
('cyborg', 0), 
('darkly', 0), 
('cerulean', 0), 
('flatly', 0),
('journal', 0),
('lumen', 0),
('paper', 0), 
('sandstone', 0),
('simplex', 0),
('slate', 0),
('spacelab', 0),
('superhero', 0),
('spacelab', 0),
('united', 0)