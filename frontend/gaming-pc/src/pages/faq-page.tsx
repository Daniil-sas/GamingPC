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
      question: "How do I become a member of TechClub?",
      answer:
        "To become a member, you need to fill out the membership application form on our website and pay the annual membership fee. After submitting your application, you'll receive a confirmation email with further instructions.",
      category: "membership",
    },
    {
      question: "What are the membership benefits?",
      answer:
        "Members get access to our facilities, workshops, events, and resources. You'll also be able to participate in club projects, networking opportunities, and receive discounts on paid workshops and events.",
      category: "membership",
    },
    {
      question: "How much is the membership fee?",
      answer:
        "The annual membership fee is $50 for students, $75 for professionals, and $200 for corporate memberships. We also offer monthly payment options.",
      category: "membership",
    },
    {
      question: "Can I book club resources without being a member?",
      answer:
        "Non-members can book certain resources at a higher rate, but priority is given to members. Some specialized equipment and spaces are exclusively available to members.",
      category: "booking",
    },
    {
      question: "How far in advance should I book resources?",
      answer:
        "We recommend booking at least 48 hours in advance for regular resources and 1 week in advance for specialized equipment or larger spaces. Peak times may require earlier bookings.",
      category: "booking",
    },
    {
      question: "What happens if I need to cancel my booking?",
      answer:
        "Cancellations made 24 hours or more before the booking time will receive a full refund or credit. Late cancellations may be subject to a cancellation fee or no refund, depending on the resource.",
      category: "booking",
    },
    {
      question: "What types of events does TechClub organize?",
      answer:
        "We organize a variety of events including workshops, hackathons, tech talks, networking sessions, project showcases, and social gatherings. Check our events calendar for upcoming activities.",
      category: "events",
    },
    {
      question: "Can I propose or host an event at TechClub?",
      answer:
        "Yes! We encourage members to propose and host events. Submit your event proposal through the member portal, and our events team will review it and get back to you.",
      category: "events",
    },
    {
      question: "Do you offer any programming courses or training?",
      answer:
        "Yes, we offer regular workshops and training sessions on various programming languages, frameworks, and technologies. Some are free for members, while others have a nominal fee.",
      category: "learning",
    },
    {
      question: "How can I contribute to club projects?",
      answer:
        "Members can join existing projects or propose new ones. Browse the projects section in the member portal to see ongoing projects and how to join them. Project leads regularly post when they need additional team members.",
      category: "projects",
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
          Frequently Asked Questions
        </h1>
        <p className="text-lg text-gray-600 mb-8">
          Find answers to common questions about TechClub membership, resources,
          and activities.
        </p>

        <div className="mb-8">
          <div className="relative">
            <input
              type="text"
              placeholder="Search FAQs..."
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
              className={`px-4 py-2 rounded-full text-sm font-medium capitalize transition-colors ${
                activeCategory === category
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
                  className={`w-full flex justify-between items-center p-4 text-left font-medium focus:outline-none ${
                    activeIndex === index ? "bg-gray-50" : "bg-white"
                  }`}
                >
                  <span className="text-gray-900">{faq.question}</span>
                  <span className="ml-4 flex-shrink-0">
                    <svg
                      className={`w-5 h-5 transition-transform ${
                        activeIndex === index ? "transform rotate-180" : ""
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
                  className={`transition-all duration-200 ease-in-out overflow-hidden ${
                    activeIndex === index
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
                No results found
              </h3>
              <p className="text-gray-600">
                We couldn't find any FAQs matching your search. Try different
                keywords or browse by category.
              </p>
            </div>
          )}
        </div>

        <div className="mt-12 p-6 bg-amber-50 border border-amber-100 rounded-lg">
          <h2 className="text-xl font-semibold text-gray-900 mb-4">
            Still have questions?
          </h2>
          <p className="text-gray-600 mb-6">
            If you couldn't find the answer you were looking for, feel free to
            reach out to our team directly.
          </p>
        </div>
      </div>
    </main>
  );
};

export default FaqPage;
