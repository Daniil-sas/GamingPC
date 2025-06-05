import { useState } from "react";
import type React from "react";

interface FaqItem {
  question: string;
  answer: string;
  category: string;
}

const FaqPage: React.FC = () => {
  const [activeIndex, setActiveIndex] = useState<number | null>(null);
  const [searchQuery, setSearchQuery] = useState("");
  const [activeCategory, setActiveCategory] = useState<string>("all");

  const faqItems: FaqItem[] = [
    {
      question: "Как стать участником компьютерного клуба «Игровой Хаб»?",
      answer:
        "Чтобы стать участником, необходимо зарегистрироваться на сайте и выбрать подходящий тарифный план. После оплаты вы получите подтверждение на email и сможете забронировать место или принять участие в мероприятиях.",
      category: "членство",
    },
    {
      question: "Какие преимущества дает участие в клубе?",
      answer:
        "Участникам доступны мощные игровые ПК.",
      category: "членство",
    },
    {
      question: "Сколько стоит посещение клуба?",
      answer:
        "Стоимость посещения — от 150 рублей в час.",
      category: "членство",
    },
    {
      question: "Можно ли бронировать места без регистрации?",
      answer:
        "Да, не зарегистрированные пользователи могут бронировать места, но с ограничениями: повышенная стоимость, ограниченный доступ к VR-зонам и запрет на участие в закрытых мероприятиях.",
      category: "бронирование",
    },
    {
      question: "Забронируйте место заранее",
      answer:
        "Рекомендуется бронировать места за 24 часа до посещения для стандартных залов и за 3 дня для VR-зон или LAN-партий. В пиковые часы (вечер/выходные) бронирование лучше делать за неделю.",
      category: "бронирование",
    },
    {
      question: "Что делать, если нужно отменить бронь?",
      answer:
        "Отмена брони за 12 часов и более — бесплатная. При отмене менее чем за 12 часов взимается 50% от стоимости. Полный возврат возможен только при наличии технических проблем в клубе.",
      category: "бронирование",
    },
    {
      question: "Какие мероприятия организует клуб?",
      answer:
        "Мы проводим киберспортивные турниры (CS:GO, Dota 2), мастер-классы по геймдизайну, хакатоны, VR-квесты и тематические вечеринки. Актуальное расписание доступно в разделе «Мероприятия».",
      category: "мероприятия",
    },
    {
      question: "Можно ли организовать свое мероприятие в клубе?",
      answer:
        "Да! Мы предоставляем площадку для проведения локальных турниров, стриминговых вечеров и IT-митапов. Подайте заявку через личный кабинет, и наш менеджер свяжется с вами для согласования деталей.",
      category: "мероприятия",
    },
    {
      question: "Есть ли в клубе обучающие программы?",
      answer:
        "Мы регулярно проводим курсы по работе с Unreal Engine, Blender и программированию на Python/C#. Некоторые занятия бесплатны для участников с абонементом, другие требуют дополнительной регистрации.",
      category: "обучение",
    },
    {
      question: "Как участвовать в совместных проектах клуба?",
      answer:
        "В личном кабинете доступен раздел «Проекты», где можно присоединиться к командам разработчиков, дизайнеров или тестировщиков. Руководители проектов публикуют открытые вакансии по мере необходимости.",
      category: "проекты",
    },
  ];

  const toggleAccordion = (index: number) => {
    setActiveIndex(activeIndex === index ? null : index);
  };

  const handleSearch = (e: React.ChangeEvent<HTMLInputElement>) => {
    setSearchQuery(e.target.value);
  };

  const filteredFaqs = faqItems.filter((item) => {
    const matchesSearch =
      item.question.toLowerCase().includes(searchQuery.toLowerCase()) ||
      item.answer.toLowerCase().includes(searchQuery.toLowerCase());

    const matchesCategory =
      activeCategory === "all" || item.category === activeCategory;

    return matchesSearch && matchesCategory;
  });

  const categories = [
    "all",
    ...Array.from(new Set(faqItems.map((item) => item.category))),
  ];

  return (
    <main className="flex-1 container mx-auto px-4 py-12">
      <div className="max-w-4xl mx-auto">
        <h1 className="text-4xl font-bold text-gray-900 mb-2">
          Часто задаваемые вопросы
        </h1>
        <p className="text-lg text-gray-600 mb-8">
          Все часто задаваемые вопросы
        </p>

        <div className="mb-8">
          <div className="relative">
            <input
              type="text"
              placeholder="Поиск..."
              value={searchQuery}
              onChange={handleSearch}
              className="w-full px-4 py-3 pl-10 border border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-amber-500 focus:border-transparent"
            />
            <svg
              className="w-5 h-5 text-gray-400 absolute left-3 top-3.5"
              fill="none"
              stroke="currentColor"
              viewBox="0 0 24 24"
              xmlns="http://www.w3.org/2000/svg"
            >
              <path
                strokeLinecap="round"
                strokeLinejoin="round"
                strokeWidth={2}
                d="M21 21l-6-6m2-5a7 7 0 11-14 0 7 7 0 0114 0z"
              />
            </svg>
          </div>
        </div>

        <div className="flex flex-wrap gap-2 mb-8">
          {categories.map((category) => (
            <button
              key={category}
              onClick={() => setActiveCategory(category)}
              className={`px-4 py-2 rounded-full text-sm font-medium capitalize transition-colors ${activeCategory === category
                  ? "bg-amber-600 text-white"
                  : "bg-gray-100 text-gray-700 hover:bg-gray-200"
                }`}
            >
              {category}
            </button>
          ))}
        </div>

        <div className="space-y-4">
          {filteredFaqs.length > 0 ? (
            filteredFaqs.map((faq, index) => (
              <div
                key={index}
                className="border border-gray-200 rounded-lg overflow-hidden"
              >
                <button
                  onClick={() => toggleAccordion(index)}
                  className={`w-full flex justify-between items-center p-4 text-left font-medium focus:outline-none ${activeIndex === index ? "bg-gray-50" : "bg-white"
                    }`}
                >
                  <span className="text-gray-900">{faq.question}</span>
                  <span className="ml-4 flex-shrink-0">
                    <svg
                      className={`w-5 h-5 transition-transform ${activeIndex === index ? "transform rotate-180" : ""
                        }`}
                      fill="none"
                      stroke="currentColor"
                      viewBox="0 0 24 24"
                      xmlns="http://www.w3.org/2000/svg"
                    >
                      <path
                        strokeLinecap="round"
                        strokeLinejoin="round"
                        strokeWidth={2}
                        d="M19 9l-7 7-7-7"
                      />
                    </svg>
                  </span>
                </button>
                <div
                  className={`transition-all duration-200 ease-in-out overflow-hidden ${activeIndex === index
                      ? "max-h-96 p-4 bg-gray-50"
                      : "max-h-0"
                    }`}
                >
                  <p className="text-gray-600">{faq.answer}</p>
                  <div className="mt-2 pt-2 border-t border-gray-100">
                    <span className="inline-block px-2 py-1 bg-gray-100 text-xs font-medium text-gray-600 rounded-full capitalize">
                      {faq.category}
                    </span>
                  </div>
                </div>
              </div>
            ))
          ) : (
            <div className="text-center py-8">
              <div className="w-16 h-16 bg-gray-100 rounded-full mx-auto mb-4 flex items-center justify-center">
                <svg
                  className="w-8 h-8 text-gray-400"
                  fill="none"
                  stroke="currentColor"
                  viewBox="0 0 24 24"
                  xmlns="http://www.w3.org/2000/svg"
                >
                  <path
                    strokeLinecap="round"
                    strokeLinejoin="round"
                    strokeWidth={2}
                    d="M9.172 16.172a4 4 0 015.656 0M9 10h.01M15 10h.01M21 12a9 9 0 11-18 0 9 9 0 0118 0z"
                  />
                </svg>
              </div>
              <h3 className="text-xl font-semibold text-gray-900 mb-2">
                Нет результатов
              </h3>
              <p className="text-gray-600">
                Напишите по другому, либо задайте вопрос напрямую нам
              </p>
            </div>
          )}
        </div>

        <div className="mt-12 p-6 bg-amber-50 border border-amber-100 rounded-lg">
          <h2 className="text-xl font-semibold text-gray-900 mb-4">
            Остались вопросы?
          </h2>
          <p className="text-gray-600 mb-6">
            Смело задавайте им нам. Для этого стоит перейти на страницу "Контакты"
          </p>
        </div>
      </div>
    </main>
  );
};

export default FaqPage;
