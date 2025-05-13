Parabéns! Encontraste o caminho positivo! Quando escolhemos ver as coisas de forma mais calma e positiva, ficamos mais tranquilos, mesmo quando sentimos ansiedade. #portrait:narration #animation:Child_happy #animation:Friend_veryHappy

Acho que já me sinto mais calmo. #portrait:speech_left #animation:Child_smiling #animation:Friend_smiling

Agora o teste começa. Olhas para a primeira pergunta e não sabes responder. #portrait:narration #show:Mask #show:PaperTest #hide:Friend #animation:Child_serious #animation:Child_sit

-> novas_escolhas

=== novas_escolhas ===
E agora? #portrait:thought #animation:Child_anxious #hide:Heart

+ [Eu devia ter estudado mais! Vou falhar o teste todo!]
    
    Eu devia ter estudado mais! Vou falhar o teste todo! #portrait:speech_left #animation:Child_veryAnxious #show:Heart
    
    Se continuares a pensar nas coisas negativas, a tua cabeça vai ficar cheia de preocupações. #portrait:speech_right #speaker:Teacher #animation:Teacher_sad
    
    Precisas de te focar no que podes fazer para melhorar, para não perderes muito tempo do teste.#animation:Teacher_serious
    -> novas_escolhas

+ [Vou avançar esta e tentar outra primeiro.]

    Vou avançar esta e tentar outra primeiro. #portrait:speech_left #animation:Child_smiling #animation:Teacher_veryHappy
    
    Às vezes mudar o que estamos a fazer ajuda-nos a tornar tudo mais tranquilo. #portrait:speech_right #speaker:Teacher #animation:Teacher_smiling
    
    Se uma pergunta é muito difícil, tentar outras mais fáceis é uma forma inteligente de pensar. 

    -> minigame_ordem_inteligente
    
+ [Vou fechar os olhos e respirar devagar.]

    Vou fechar os olhos e respirar devagar. #portrait:speech_left #animation:Child_smiling #animation:Teacher_veryHappy
    
    Quando estamos nervoso, o nosso coração bate mais rápdo, mas com respirações profundas, conseguimos acalmar esse sentimento. #portrait:speech_right #speaker:Teacher #animation:Teacher_smiling
    
    Imagina que tens uma flor na mão e uma vela na outra. #show:Flower #show:Candle
    
    Agora cheira a flor bem devagar pelo nariz... #hide:Candle #show:Inspirar #hide:Expirar
    
    E agora sopra a vela com calma pela boca... #hide:Flower #show:Candle #animation:Child_happy #animation:Teacher_happy #hide:Inspirar #show:Expirar
    
    Outra vez! Cheira a flor... #show:Flower #hide:Candle #animation:Teacher_smiling #show:Inspirar #hide:Expirar
    
    Sopra a vela... #show:Candle #hide:Flower #animation:Child_happy #animation:Teacher_happy #hide:Inspirar #show:Expirar
    
    Muito bem! Quando respiras assim o teu corpo acalma e a ansiedade começa a ir embora. #animation:Child_veryHappy #hide:Candle #animation:Teacher_veryHappy #hide:Inspirar #hide:Expirar

    -> continue4
    
=== continue3 ===
Parabéns! Ao escolheres começar pelas perguntas mais fáceis conseguiste controlar a ansiedade durante o teste. Foi uma escolha inteligente! #portrait:narration #animation:Child_happy #animation:Teacher_happy

-> continue4

=== continue4 ===
Boa! Consegui terminar! #portrait:speech_left #animation:Child_veryHappy #animation:Teacher_veryHappy

Foi difícil, mas conseguiste controlar a ansiedade! #portrait:speech_right

Mesmo sentindo ansiedade conseguiste fazer o teste. Ao acalmares o teu corpo e organizares os teus pensamentos consegues passar qualquer desafio! #portrait:narration #animation:Child_happy #animation:Teacher_happy

-> END

=== minigame_ordem_inteligente ===
Minijogo Ordem Inteligente #minigame:OrdemInteligente
-> continue3