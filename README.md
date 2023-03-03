# RunnerTools

A aplicação pretende auxiliar corredores no planeamento e análise de treinos.

Deverá permitir a realização de cálculos básicos de conversão e cálculos de ritmo para diferentes tipos de treino.

Deverá obter informação, em outras plataformas, de treinos realizados. Essas informações deverão ficar armazenadas para possibilitar seu uso em comparações e estatísticas.

Deverá utilizar autenticação para que permita armazenamento de dados por utilizador e para que possa vincular cada utilizador com seu utilizador de outras plataformas.

## Cálculos básicos

Possivelmente para uso sem autenticação, deverá fornecer os seguintes cálculos:

1. Conversão de velocidade (km/h) para ritmo (min/km) e vice-versa
   - Exemplo: 10,00 km/h -> 10,00/60 min -> 6,00 min/km
   - Exemplo: 6,00 min/km -> 60,00/10 km -> 10,00 km/h
   
2. Cálculo de ritmo (dada distância e tempo desejados)
   - Exemplo: 10 km em 50 minutos -> 5 min/km
   
3. Cálculo de velocidade (dada uma distância e tempo desejados)
   - Exemplo: 10 km em 50 minutos -> 12 min/km
   
4. Cálculo de tempo (dados ritmo e distância desejados)
   - Exemplo: 21,097 km (meia maratona) com ritmo de 5:30 min/km -> 1:56:02

## Cálculos de treinos

A aplicação considerará que cada treino é proposto com algumas informações de referência:

- Tipo de treino (Regenerativo, Ritmo, Progressivo e Fartlek)
- Distância
- Tipo de terreno (indiferente para os cálculos)
- Duração mínima
- Duração máxima

Com esses dados a aplicação deverá calcular ritmo para 3 cenários:

1. Treino forte (duração mínima)
2. Treino médio (duração média)
3. Treino leve (duração máxima)

Os cálculos deverão definir o ritmo para cada intervalo de distância (1 km).

Para utilizadores autenticados, deverá permitir:

1. Calcular ritmos para tipos de treino diferentes

   i. **Treino Regenerativo**: Treino leve, sem necessidade de variações de ritmo por km
      - *Exemplo*: 6 km entre 35 min e 42 min
         - Forte: ritmo de 5:50 min/km (duração total de 35:00 min)
         - Médio: ritmo de 6:25 min/km (duração total de 38:30 min)
         - Leve: ritmo de 7:00 min/km (duração total de 42:00 min)
        
   ii. **Treino de Ritmo**: Treino forte, mas sem necessidade de variações de ritmo por km
      - *Exemplo*: 7 km entre 35 min e 42 min
         - Forte: ritmo de 5:00 min/km (duração total de 35:00 min)
         - Médio: ritmo de 5:30 min/km (duração total de 38:30 min)
         - Leve: ritmo de 6:00 min/km (duração total de 42:00 min)
        
   iii. **Treino Progressivo**: Treino em que o ritmo deve ser menor (mais rápido) a cada intervalo (km)
      - *Exemplo*: 5 km entre 30 min e 34 min (o utilizador precisará definir um dos ritmos para que seja calculado o outro)
         - Forte: ritmos de 6:10 min/km (leve) e 5:45 min/km (forte) (duração total de 30:00 min)
         - Médio: ritmos de 6:45 min/km (leve) e 5:52 min/km (forte) (duração total de 31:59 min)
         - Leve: ritmos de 7:00 min/km (leve) e 6:30 min/km (forte) (duração total de 34:00 min)
        
   iv. **Treino Fartlek**: Treino em que deve haver 2 ritmos diferentes e alternados por intervalo (km). Deve sempre iniciar com o ritmo mais leve/lento
      - *Exemplo*: 6 km entre 34 min e 40 min (o utilizador precisará definir um dos ritmos e a variação de ritmo ou os 2 ritmos para que sejam calculados os ritmos de cada intervalo)
         - Forte: ritmos de 6:20 min/km (leve) à 5:00 min/km (forte), com redução de 16 seg/km no ritmo (duração total de 34:00 min)
         - Médio: ritmos de 6:40 min/km (leve) e 5:40 min/km (forte), com redução de 12 seg/km no ritmo (duração total de 37:00 min)
         - Leve: ritmos de 7:00 min/km (leve) à 6:20 min/km (forte), com redução de 8 seg/km no ritmo (duração total de 40:00 min)
   
2. Vincular conta com outras plataformas (lista abaixo)
3. Obter informações de treinos de outras plataformas (atenção para treinos repetidos em plataformas diferentes)
4. Permitir comparar treino planeado com executado
   - Permitir gravar comparativo, com adição de outras informações (observações, etc)


## Recursos Premium

1. Exportar treino para outras plataformas (lista abaixo)
2. Exportar plano de treino (descarregar ficheiro FIT/TCX/GPX)
 
## Plataformas de interesse

- [Garmin](https://developer.garmin.com/fit/overview/)
- [Suunto](https://apizone.suunto.com/docs/services/)
- [Polar](https://www.polar.com/accesslink-api/#polar-accesslink-api)
- [Google Fit](https://developers.google.com/fit/rest?hl=pt-br)
- [Runkeeper](https://runkeeper.com/developer/healthgraph) (restrito à parceiros - [StackOverflow](https://stackoverflow.com/questions/62769836/runkeeper-health-graph-api-documentation))
- Nike Run
- [MapMyRun](https://developer.underarmour.com/docs/)

## Perfis de utilizador

De partida haverá apenas 1 perfil de utilizador, para que seja possível autenticar na aplicação.

No entanto, podemos adicionar recursos Premium e autorizar consoante perfil/perfis de utilizador Premium.

## Modelo de utilização

Visitantes poderão utilizar apenas os cálculos básicos.

Para utilizar cálculos de treinos, será preciso criar uma conta de utilizador e autenticar-se na aplicação.

Recursos avançados só serão acessíveis para utilizadores com perfil 'premium'.

|                           | Recursos básicos | Recursos avançados | Recursos Premium |
| ------------------------- | :--------------: | :----------------: | :--------------: |
| **Visitante**             |     &#10004;     |      &#10006;      |     &#10006;     |
| **Autenticado**           |     &#10004;     |      &#10004;      |     &#10006;     |
| **Assinante autenticado** |     &#10004;     |      &#10004;      |     &#10004;     |

