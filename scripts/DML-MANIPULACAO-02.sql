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