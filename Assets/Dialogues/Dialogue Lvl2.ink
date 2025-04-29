É hora de jantar, e os teus pais preparam um prato diferente. #portrait:narration
Quando olhas para a comida sentes um desconforto na barriga e vontade de vomitar...

-> minigame_puzzle_nojo

=== continue1 ===
Parabéns, reconheceste o nojo! O nojo aparece quando algo parece estranho ou nos faz sentir desconfortáveis, como um cheiro mau. #portrait:narration

Experimenta! É uma receita nova e faz bem à saúde. #portrait:speech_right 

-> main

=== main ===

Será que quero experimentar? #portrait:thought

+ [Não! Isso é nojento!]

    Não! Isso é nojento! #portrait:speech_left
    
    Se não experimentares nunca vais saber se gostas ou não. #portrait:speech_right
    
    Às vezes a melhor maneira de descobrir é dar uma oportunidade!
    -> main
    
+ [Até posso provar, mas enquanto como vou pensar que estou a comer outra coisa que gosto.]

    Até posso provar, mas enquanto como vou pensar que estou a comer outra coisa que gosto. #portrait:speech_left
    
    Pensar noutra comida não vai mudar o sabor. #portrait:speech_right
    Mas se pensares no que cada legume faz de bom vai ser mais fácil experimentar!
    A cenoura ajuda na visão, e os bróculos são ótimos para dar força aos ossos e para a saúde.
    -> main
    
+ [Se faz bem à saúde, eu posso tentar comer um pedaço.]

    Se faz bem à saúde, eu posso tentar comer um pedaço. #portrait:speech_left
    
    Boa! Vais ver que vais gostar! Consegues adivinhar o que tem? #portrait:speech_right
    -> minigame_prato_misterioso

=== continue2 ===
Parabéns! Aprendeste a reconhecer os ingredientes no teu prato e a experimentar novos sabores. Estás no caminho certo para ser um verdadeiro chef! #portrait:narration

Vês? Experimentar não foi assim tão mau! #portrait:speech_right

Ainda não adoro, mas consegui comer um pouco. #portrait:speech_left

E isso já é um grande passo. O teu paladar pode mudar com o tempo! #portrait:speech_right

Explorar novos sabores é uma aventura! Mesmo que ainda não adores, sabes que esses alimentos fazem bem à tua saúde e vão ajudar-te a ser ainda mais forte e saudável. #portrait:narration

-> END

=== minigame_puzzle_nojo ===
Qual é a emoção que o João está a sentir? #portrait:narration #minigame:PuzzleNojo
-> continue1

=== minigame_prato_misterioso ===
Minijogo Prato Misterioso #minigame:PratoMisterioso
-> continue2
