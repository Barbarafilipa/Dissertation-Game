Hoje é o dia do teste de matemática. #portrait:narration
Sentes o teu coração a bater mais rápido, as mãos a suar e um nó na barriga...

-> minigame_puzzle_ansiedade

=== continue1 ===
Parabéns, reconheceste a ansiedade! A ansiedade aparece quando temos medo do que pode acontecer no futuro e não sabemos exatamente como vai ser. #portrait:narration

Ei, estás pronto para o teste? #portrait:speech_right #speaker:Friend

-> main

=== main ===
E se eu errar tudo? #portrait:thought

+ [Não, vou dizer à professora que estou doente para não fazer.]

    Não, vou dizer à professora que estou doente para não fazer. #portrait:speech_left
    
    Mesmo que digas que estás doente, um dia vais ter que fazer o teste e a ansiedade vai ser maior ainda. #portrait:speech_right
    
    Fazer o teste agora pode ser difícil, mas depois não precisas de te preocupar mais com ele.
    
    -> main
    
+ [Estou ansioso, mas vou tentar fazer o teste.]

    Estou ansioso, mas vou tentar fazer o teste. #portrait:speech_left
    
    Vou te contar um segredo, eu também estou nervoso para o teste. #portrait:speech_right
    
    Mas às vezes não podemos evitar que isso aconteça.
    
    Temos que pensar de forma calma para conseguirmos lidar com a ansiedade.
    -> minigame_cano_dos_pensamentos
    
+ [Eu estudei muito, então vai correr bem.]

    Eu estudei muito, então vai correr bem. #portrait:speech_left
    
    Isso mesmo, tens que pensar que estudaste muito e que por isso vais saber responder a tudo. #portrait:speech_right
    
    Um teste é apenas uma avaliação, se não correr bem, depois podes melhorar nos próximos.
    -> minigame_cano_dos_pensamentos

=== continue2 ===
Parabéns! Encontraste o caminho positivo! Quando escolhemos ver as coisas de forma mais calma e positiva, ficamos mais tranquilos, mesmo quando sentimos ansiedade. #portrait:narration

Acho que já me sinto mais calmo. #portrait:speech_left

Agora o teste começa. Olhas para a primeira pergunta e não sabes responder. #portrait:narration #hide:Friend

-> novas_escolhas

=== novas_escolhas ===
E agora? #portrait:thought

+ [Eu devia ter estudado mais! Vou falhar o teste todo!]
    
    Eu devia ter estudado mais! Vou falhar o teste todo! #portrait:speech_left
    
    Se continuares a pensar nas coisas negativas, a tua cabeça vai ficar cheia de preocupações. #portrait:speech_right #speaker:Teacher
    
    Precisas de te focar no que podes fazer para melhorar, para não perderes muito tempo do teste.
    -> novas_escolhas

+ [Vou avançar esta e tentar outra primeiro.]

    Vou avançar esta e tentar outra primeiro. #portrait:speech_left
    
    Às vezes mudar o que estamos a fazer ajuda-nos a tornar tudo mais tranquilo. #portrait:speech_right #speaker:Teacher
    
    Se uma pergunta é muito difícil, tentar outras mais fáceis é uma forma inteligente de pensar. 

    -> minigame_ordem_inteligente
    
+ [Vou fechar os olhos e respirar devagar.]

    Vou fechar os olhos e respirar devagar. #portrait:speech_left
    
    Quando estamos nervoso, o nosso coração bate mais rápdo, mas com respirações profundas, conseguimos acalmar esse sentimento. #portrait:speech_right #speaker:Teacher
    
    Imagina que tens uma flor na mão e uma vela na outra.
    
    Agora cheira a flor bem devagar pelo nariz...
    
    E agora sopra a vela com calma pela boca...
    
    Outra vez! Cheira a flor...
    
    Sopra a vela...
    
    Muito bem! Quando respiras assim o teu corpo acalma e a ansiedade começa a ir embora.

    -> continue4
    
=== continue3 ===
Parabéns! Ao escolheres começar pelas perguntas mais fáceis conseguiste controlar a ansiedade durante o teste. Foi uma escolha inteligente! #portrait:narration

-> continue4

=== continue4 ===
Boa! Consegui terminar! #portrait:speech_left

Foi difícil, mas conseguiste controlar a ansiedade! #portrait:speech_right

Mesmo sentindo ansiedade conseguiste fazer o teste. Ao acalmares o teu corpo e organizares os teus pensamentos consegues passar qualquer desafio! #portrait:narration

-> END

=== minigame_puzzle_ansiedade ===
Qual é a emoção que o João está a sentir? #portrait:narration #minigame:PuzzleAnsiedade
-> continue1

=== minigame_cano_dos_pensamentos ===
Minijogo Cano dos Pensamentos #minigame:CanoDosPensamentos
-> continue2

=== minigame_ordem_inteligente ===
Minijogo Ordem Inteligente #minigame:OrdemInteligente
-> continue3
