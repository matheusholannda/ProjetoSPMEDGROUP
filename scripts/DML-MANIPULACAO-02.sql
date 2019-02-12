BULK INSERT ESPECIALIDADES
FROM 'C:\db\ESPECIALIDADE.CSV'
	WITH(
		FORMAT = 'csv',
		FIRSTROW = 2, -- primeira linha de dados = 2 
		FIELDTERMINATOR = ';', -- separador de campos = ';'
		ROWTERMINATOR = '\n', -- separador de linhas = '\n'
		CODEPAGE = 'ACP', -- codificação dos dados = 'ACP'
		DATAFILETYPE = 'Char' -- tipo do arquivo = 'Char'
);

BULK INSERT CONSULTAS
FROM 'C:\db\CONSULTAS.CSV'
	WITH(
		FORMAT = 'csv',
		FIRSTROW = 2, -- primeira linha de dados = 2 
		FIELDTERMINATOR = ';', -- separador de campos = ';'
		ROWTERMINATOR = '\n', -- separador de linhas = '\n'
		CODEPAGE = 'ACP', -- codificação dos dados = 'ACP'
		DATAFILETYPE = 'Char' -- tipo do arquivo = 'Char'
);

BULK INSERT MEDICOS
FROM 'C:\db\MEDICOS.CSV'
	WITH(
		FORMAT = 'csv',
		FIRSTROW = 2, -- primeira linha de dados = 2 
		FIELDTERMINATOR = ';', -- separador de campos = ';'
		ROWTERMINATOR = '\n', -- separador de linhas = '\n'
		CODEPAGE = 'ACP', -- codificação dos dados = 'ACP'
		DATAFILETYPE = 'Char' -- tipo do arquivo = 'Char'
);

BULK INSERT TIPO_USUARIOS
FROM 'C:\db\TIPO_USUARIOS.CSV'
	WITH(
		FORMAT = 'csv',
		FIRSTROW = 2, -- primeira linha de dados = 2 
		FIELDTERMINATOR = ';', -- separador de campos = ';'
		ROWTERMINATOR = '\n', -- separador de linhas = '\n'
		CODEPAGE = 'ACP', -- codificação dos dados = 'ACP'
		DATAFILETYPE = 'Char' -- tipo do arquivo = 'Char'
);

BULK INSERT USUARIOS
FROM 'C:\db\USUARIOS.CSV'
	WITH(
		FORMAT = 'csv',
		FIRSTROW = 2, -- primeira linha de dados = 2 
		FIELDTERMINATOR = ';', -- separador de campos = ';'
		ROWTERMINATOR = '\n', -- separador de linhas = '\n'
		CODEPAGE = 'ACP', -- codificação dos dados = 'ACP'
		DATAFILETYPE = 'Char' -- tipo do arquivo = 'Char'
);

BULK INSERT PRONTUARIO_PACIENTE
FROM 'C:\db\PRONTUARIO_PACIENTE.CSV'
	WITH(
		FORMAT = 'csv',
		FIRSTROW = 2, -- primeira linha de dados = 2 
		FIELDTERMINATOR = ';', -- separador de campos = ';'
		ROWTERMINATOR = '\n', -- separador de linhas = '\n'
		CODEPAGE = 'ACP', -- codificação dos dados = 'ACP'
		DATAFILETYPE = 'Char' -- tipo do arquivo = 'Char'
);
