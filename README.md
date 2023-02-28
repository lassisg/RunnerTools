# RunnerTools

A aplicação pretende auxiliar corredores no planeamento e análise de treinos.

Deverá permitir a realização de cálculos básicos de conversão e cálculos de ritmo para diferentes tipos de treino.

Deverá obter informação, em outras plataformas, de treinos realizados. Essas informações deverão ficar armazenadas para possibilitar seu uso em comparações e estatísticas.

Deverá utilizar autenticação para que permita armazenamento de dados por utilizador e para que possa vincular cada utilizador com seu utilizador de outras plataformas.

## Cálculos básicos

Possivelmente para uso sem autenticação, deverá fornecer os seguintes cálculos:

- Conversão de velocidade (km/h) para ritmo (min/km)
- Ritmo médio, dada uma distância
- Velocidade média, dada uma distância

## Cálculos de treinos

Para utilizadores autenticados, deverá permitir:

- Vincular conta com outras plataformas (lista abaixo)
- Obter informações de treinos de outras plataformas (atenção para trinos repetidos em plataformas diferentes)
- Calcular ritmos para tipos de treino diferentes (Ritmo, Regenerativo, Progressivo, Fartlek e, possivelmente, Tiros)
- Enviar para outras plataformas o treino criado
- Permitir comparar treino planeado com executado
  - Permitir gravar comparativo, com adicção de outras informações (observações, etc)

## Plataformas de interesse

- Garmin
- Nike Run
- Suunto
- Polar
- Runkeeper
- Google Fit
