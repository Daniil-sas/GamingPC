import type React from "react";

const HomePage: React.FC = () => {
  return (
    <main className="flex-1 container mx-auto px-4 py-8">
      <section className="text-center py-16">
        <h1 className="text-5xl font-bold text-gray-900 mb-6">
          Welcome to <span className="text-amber-600">TechClub</span>
        </h1>
        <p className="text-xl text-gray-600 mb-8 max-w-2xl mx-auto">
          Join our community of passionate developers, designers, and tech
          enthusiasts. Learn, build, and grow together in the world of
          technology.
        </p>
        <div className="space-x-4">
          <button className="bg-amber-600 hover:bg-amber-700 text-white px-8 py-3 rounded-lg font-semibold transition-colors">
            Join Now
          </button>
          <button className="border-2 border-gray-900 text-gray-900 hover:bg-gray-900 hover:text-white px-8 py-3 rounded-lg font-semibold transition-colors">
            Learn More
          </button>
        </div>
      </section>

      <section className="grid md:grid-cols-3 gap-8 py-16">
        <div className="text-center p-6 border border-gray-200 rounded-lg">
          <div className="w-16 h-16 bg-amber-600 rounded-full mx-auto mb-4 flex items-center justify-center">
            <span className="text-white text-2xl font-bold">💻</span>
          </div>
          <h3 className="text-xl font-semibold mb-2">Coding Workshops</h3>
          <p className="text-gray-600">
            Learn programming languages and frameworks through hands-on
            workshops.
          </p>
        </div>

        <div className="text-center p-6 border border-gray-200 rounded-lg">
          <div className="w-16 h-16 bg-amber-600 rounded-full mx-auto mb-4 flex items-center justify-center">
            <span className="text-white text-2xl font-bold">🚀</span>
          </div>
          <h3 className="text-xl font-semibold mb-2">Project Building</h3>
          <p className="text-gray-600">
            Collaborate on real-world projects and build your portfolio.
          </p>
        </div>

        <div className="text-center p-6 border border-gray-200 rounded-lg">
          <div className="w-16 h-16 bg-amber-600 rounded-full mx-auto mb-4 flex items-center justify-center">
            <span className="text-white text-2xl font-bold">🤝</span>
          </div>
          <h3 className="text-xl font-semibold mb-2">Networking</h3>
          <p className="text-gray-600">
            Connect with like-minded individuals and industry professionals.
          </p>
        </div>
      </section>
    </main>
  );
};

export default HomePage;
